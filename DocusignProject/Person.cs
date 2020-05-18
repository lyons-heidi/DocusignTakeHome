using System;
using System.Collections.Generic;
using System.Linq;

namespace DocusignProject
{
    public class Person
    {
        private List<string> commands;
        private string weather;
        private string finalResp;
        private List<string> visited;

        public Person(string strInput)
        {
            this.commands = new List<string>();
            this.visited = new List<string>();
            this.finalResp = "";

            ParseInput(strInput);
        }

        private void ParseInput(string strInput)
        {
            // strInput: "HOT 1, 2, 3, 4, 5"

            char[] delimiterChars = { ' ', ',' };
            int firstIndex = strInput.IndexOf(' ');

            string weatherStr = strInput.Substring(0, firstIndex);
            string commandstr = strInput.Substring(firstIndex + 1);

            List<string> steps = commandstr.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries).ToList();

            System.Console.WriteLine(weatherStr);

            foreach (var step in steps)
            {
                System.Console.WriteLine($"<{step}>");
            }

            // save weather and array of steps
            this.weather = weatherStr;
            this.commands = steps;

        }
        public string ValidateData()
        {
            string[,] hotColdResponses = new string[8, 2]{
                                {"sandals", "boots"},
                                {"sun visor", "hat"},
                                {"fail", "socks"},
                                {"t-shirt", "shirt"},
                                {"fail", "jacket"},
                                {"shorts", "pants"},
                                {"leaving house", "leaving house"},
                                {"Removing PJs", "Removing PJs"}

                            };
            // Once a weather choice is selected, we'll only base responses on that choice
            int weatherChoice = 0;

            if (this.weather == "HOT")
            {
                weatherChoice = 0;
            }
            else if (this.weather == "COLD")
            {
                weatherChoice = 1;
            }
            else
            {
                this.finalResp.Concat("fail");
                return this.finalResp;
            }

            for (int i = 0; i < this.commands.Count - 1; i++)
            {
                //  Initial state is in your house with your pajamas on
                //  Pajamas must be taken off before anything else can be put on
                if (i == 0)
                {
                    if (this.commands[i] != "8")
                    {
                        this.finalResp = this.finalResp + "fail";
                        return this.finalResp;
                    }
                    else
                    {
                        this.visited.Add(this.commands[i]);
                        this.finalResp = this.finalResp + hotColdResponses[7, weatherChoice] + ", ";
                    }
                }

                // put on socks 
                else if (this.commands[i] == "3")
                {
                    if (this.weather == "COLD" && !this.visited.Contains(this.commands[i]))
                    {
                        this.finalResp = this.finalResp + hotColdResponses[Int32.Parse(this.commands[i]) - 1, weatherChoice] + ", ";
                        this.visited.Add(this.commands[i]);
                    }
                    // You cannot put on socks when it is hot
                    // You cannot put on more than one pair of socks
                    else
                    {
                        this.finalResp = this.finalResp + "fail";
                        return this.finalResp;
                    }
                }

                // put on shirt
                else if (this.commands[i] == "4")
                {
                    if (!this.visited.Contains(this.commands[i]))
                    {
                        this.finalResp = this.finalResp + hotColdResponses[Int32.Parse(this.commands[i]) - 1, weatherChoice] + ", ";
                        this.visited.Add(this.commands[i]);
                    }
                    else
                    {
                        this.finalResp = this.finalResp + "fail";
                        return this.finalResp;
                    }
                }

                // put on jacket 
                else if (this.commands[i] == "5")
                {
                    if (this.weather == "COLD" && this.visited.Contains("4") && !this.visited.Contains(this.commands[i]))
                    {
                        this.finalResp = this.finalResp + hotColdResponses[Int32.Parse(this.commands[i]) - 1, weatherChoice] + ", ";
                        this.visited.Add(this.commands[i]);
                    }
                    // You cannot put on a jacket when it is hot
                    // You cannot put on a jacket without a shirt
                    // You cannot put on more than one jacket
                    else
                    {
                        this.finalResp = this.finalResp + "fail";
                        return this.finalResp;
                    }
                }

                // put on shoes
                else if (this.commands[i] == "1")
                {
                    if (this.weather == "HOT" && !this.visited.Contains("6"))
                    {
                        this.finalResp = this.finalResp + "fail";
                        return this.finalResp;
                    }
                    else if (this.weather == "COLD" && (!this.visited.Contains("6") || !this.visited.Contains("2")))
                    {
                        this.finalResp = this.finalResp + "fail";
                        return this.finalResp;
                    }
                    else
                    {
                        this.finalResp = this.finalResp + hotColdResponses[Int32.Parse(this.commands[i]) - 1, weatherChoice] + ", ";
                        this.visited.Add(this.commands[i]);
                    }
                }

                // put on pants
                else if (this.commands[i] == "6")
                {
                    if (this.visited.Contains("6"))
                    {
                        this.finalResp = this.finalResp + "fail";
                        return this.finalResp;
                    }
                    this.finalResp = this.finalResp + hotColdResponses[Int32.Parse(this.commands[i]) - 1, weatherChoice] + ", ";
                    this.visited.Add(this.commands[i]);
                }

                // if headwear, make sure shirt is on first
                else if (this.commands[i] == "2")
                {
                    if (this.visited.Contains("4") && !this.visited.Contains("2"))
                    {
                        this.finalResp = this.finalResp + hotColdResponses[Int32.Parse(this.commands[i]) - 1, weatherChoice] + ", ";
                        this.visited.Add(this.commands[i]);
                    }
                    else
                    {
                        this.finalResp = this.finalResp + "fail";
                        return this.finalResp;
                    }
                }

                // If an invalid command is issued, respond with “fail” and stop processing commands
                else
                {
                    this.finalResp = this.finalResp + "fail";
                    return this.finalResp;
                }
            }

            // You cannot leave the house until all items of clothing are on (except socks and a jacket when it’s hot)
            if (this.weather == "COLD")
            {
                System.Console.WriteLine("");
                List<string> expected = new List<string> { "1", "2", "3", "4", "5", "6", "8" };
                if (!Enumerable.SequenceEqual(this.visited.OrderBy(e => e), expected.OrderBy(e => e)))
                {
                    this.finalResp = this.finalResp + "fail";
                    return this.finalResp;
                }
            }

            else if (this.weather == "HOT")
            {
                List<string> expected = new List<string> { "1", "2", "4", "6", "8" };
                if (!Enumerable.SequenceEqual(this.visited.OrderBy(e => e), expected.OrderBy(e => e)))
                {
                    this.finalResp = this.finalResp + "fail";
                    return this.finalResp;
                }
            }

            // leaving house
            if (this.commands[commands.Count - 1] == "7")
            {
                if (this.visited.Contains("7"))
                {
                    this.finalResp = this.finalResp + "fail";
                    return this.finalResp;
                }
                this.finalResp = this.finalResp + hotColdResponses[Int32.Parse(this.commands[commands.Count - 1]) - 1, weatherChoice];
                this.visited.Add(this.commands[commands.Count - 1]);
            }


            return this.finalResp;
        }
    }
}
