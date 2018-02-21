/*This small application written by Shreevidhya Ganesan that asks Names and three health related questions from the 
 user. The user names and reponses are received as inputs from the console and stored in the list <UserResponses>
 of type UserResponse(a class which contains names and their corresponding response for the questions)
 Accepting inputs will be terminated on pressing Enter when asked for Name.
 Finally the List of Data is stored in and read from the text file named Data.txt.
 */



using System;
using System.Collections.Generic;
using System.IO;

namespace Shreevidhya_Assignment
{
	class UserResponse
	{
		public string Name { get; set; }
		public string HealthResponse1 { get; set; }
		public string HealthResponse2 { get; set; }
		public string HealthResponse3 { get; set; }

		public UserResponse(string name, string res1, string res2, string res3)
		{
			Name = name;
			HealthResponse1 = res1;
			HealthResponse2 = res2;
			HealthResponse3 = res3;
		}
		public override string ToString()
		{
			string str = Name + "," + HealthResponse1 + "," + HealthResponse2 + "," + HealthResponse3;
			return str;
		}

	}
	class MainClass
	{
		public static void Main(string[] args)
		{
			List<UserResponse> UserResponses = new List<UserResponse>();
			string HealthResponse1;
			string HealthResponse2;
			string HealthResponse3;
			bool askForUser = true;
			Console.WriteLine("Press [enter] for to end");
			while (askForUser == true)
			{
				//get User name
				string name = AskForResponse("Name: ");
				if (string.IsNullOrWhiteSpace(name))
					break;

				//get Response for Question1
				HealthResponse1 = AskForResponse("Are you feeling tired and lazy? ");

				//get Response for Question2
				HealthResponse2 = AskForResponse("How is your appetite? ");

				//get Response for Question3
				HealthResponse3 = AskForResponse("How is your sleep cycle? ");

				//Add to the list
				UserResponses.Add(new UserResponse(name, HealthResponse1, HealthResponse2, HealthResponse3));

			}

			//Printing the responses of the user
			Console.WriteLine("List of Users and their Responses");

			//Print the responses from List
			/*for (var i = 0; i < UserResponses.Count; i++)
            {
                Console.WriteLine(UserResponses[i]);
            }*/

			SaveToTxt(UserResponses);
			ReadFromTxt();
		}

		//To Ask for Response
		private static string AskForResponse(string Question)
		{
			Console.Write(Question);
			return Console.ReadLine();
		}

		//Save the Responses to the txt file
		public static void SaveToTxt(List<UserResponse> UserResponses)
		{
			using (TextWriter tw = new StreamWriter(System.Environment.CurrentDirectory + @"\Data.txt", true))
			{
				foreach (var item in UserResponses)
				{
					tw.WriteLine(item);
				}
			}
		}

		//Retrive the Responses from the txt file
		public static void ReadFromTxt()
		{
			string line;
			using (TextReader tw = new StreamReader(System.Environment.CurrentDirectory + @"\Data.txt"))
			{
				while ((line = tw.ReadLine()) != null)
				{
					System.Console.WriteLine(line);
				}
			}
		}

	}
}

