using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Netology06HomeWorkCollestions
{
    internal class TrackList
    {
        private char _id;
        private string _name;
        private TrackList? _next;
        private TrackList? _previous;
        public char Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public TrackList Next { get { return _next; } set { _next = value; } }
        public TrackList Previous { get { return _previous; } set { _previous= value; } }
        public bool IsTheEnd { get; set; }
        public bool IsTheStart { get; set; }
        
        public TrackList(): this('\0', " ") {}
        public TrackList(char point, string name)
        {
            _id = point;
            _name = name;
        }

        public static void ShowInstructions()
        {
            Console.WriteLine("push ESC - For exit from task");
            Console.WriteLine("push Tab - to look example of track");
            Console.WriteLine("push Enter - To input your track");
            Console.WriteLine("push \"S\"how - to look your track");
            Console.WriteLine("push \"R\"everse - to look your track backwards");
            Console.WriteLine("push \"С\"lear - to clear console");
            Console.WriteLine("=================================");
        }
        public static void TaskLoop()
        {
            ShowInstructions();
            TrackList tempNode = new TrackList();
            bool breakLoop = false;

            var nodeA = new TrackList('A', "Эрмитаж");
            var nodeB = new TrackList('B', "Казанский собор");
            var nodeC = new TrackList('C', "Адмиралтейство");
            
            nodeA.Next = nodeB;
            nodeA.IsTheStart = true;

            nodeB.Next = nodeC;
            nodeC.Next = nodeA;
            nodeC.IsTheEnd = true;

            nodeA.Previous = nodeC;
            nodeB.Previous = nodeA;
            nodeC.Previous = nodeB;    

            List<TrackList> userTrack = new List<TrackList>();
            while (!breakLoop)
            {
                var key = Console.ReadKey(true);

                switch (key.Key)
                {

                    case ConsoleKey.Escape:
                        breakLoop = true;
                        Console.WriteLine("See you later!");
                        break;
                    case ConsoleKey.Enter:
                        Console.WriteLine("input End for finish");
                        char numPoint = 'A';
                        while (true)
                        {
                            string pointName = Console.ReadLine();
                            if (pointName == "End" || pointName == "end") { Console.Clear(); ShowInstructions();  break; }
                            var setUserPoint = new TrackList(numPoint, pointName);
                            userTrack.Add(setUserPoint);
                            numPoint++;
                        }
                        for (int i = 0; i<userTrack.Count(); i++)
                        {
                            var tempUserPoint = new TrackList();
                            int tempPrevId = i - 1;
                            int tempNextId = i + 1;
                            tempUserPoint = userTrack[i];
                            tempUserPoint.IsTheStart = false;
                            tempUserPoint.IsTheEnd = false;

                            if (i==0)
                            { 
                                tempUserPoint.IsTheStart = true;
                                tempPrevId = 0;
                            }
                            else if(i == userTrack.Count()-1)
                            {
                                
                                tempUserPoint.IsTheEnd = true;
                                tempNextId = 0;
                            }
                            tempUserPoint.Previous = userTrack[tempPrevId];
                            tempUserPoint.Next = userTrack[tempNextId];

                        }
                 
                        break;
                    case ConsoleKey.Tab:
                        tempNode = nodeA;
                        while (true)
                        {
                            Console.WriteLine(tempNode.Name);
                            if (tempNode.IsTheEnd) { break; }
                            tempNode = tempNode.Next;
                        }
                        break;
                    case ConsoleKey.S:
                        tempNode = userTrack[0];
                        while (true)
                        {
                            Console.WriteLine(tempNode.Name);
                            if (tempNode.IsTheEnd) { break; }
                            tempNode = tempNode.Next;
                        }

                        break;
                    case ConsoleKey.R:
                        tempNode = userTrack[userTrack.Count()-1];
                        while (true)
                        {
                            Console.WriteLine(tempNode.Name);
                            if (tempNode.IsTheStart) { break; }
                            tempNode = tempNode.Previous;
                        }

                        break;
                    case ConsoleKey.C:
                        Console.Clear(); ShowInstructions();
                        break; 
                }
            }
        }
    }
}
