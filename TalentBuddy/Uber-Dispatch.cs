using System;
using System.Collections.Generic;
using System.Linq;
// finding the shortest distance in a graph : http://www.talentbuddy.co/challenge/523cc5174af0110af38303a6
class Edge
{
    public int Start;
    public int End;
    public int Length;
    public Edge(string start,string end, string length)
    {
        Start=Convert.ToInt32(start);
        End=Convert.ToInt32(end);
        Length=Convert.ToInt32(length);
    }
    public int FromGoTo(int start)
    {
        return (start==Start)?End:Start;
    }
    public bool IsConnectedTo(int node)
    {
        return node==Start || node == End;
    }
}
class MyClass {
    int minimal;
    int carId;
    public List<Edge> Edges=new List<Edge>();
    public Dictionary<int,int> CarLocations=new Dictionary<int,int>();
    
    public void find_closest_car(string[] city_map, int[] cars, int customer) {
        for(int i=0;i<cars.Length;i++)
        {
            CarLocations.Add(cars[i],i+1);
        }
        for (int i=0;i<city_map.Length;i++)
        {
            string [] details=city_map[i].Split(',');
            Edge e=new Edge (details[0],details[1],details[2]);
            Edges.Add(e);
        }
        minimal=Int32.MaxValue;
        carId=Int32.MaxValue;
        GetIdFrom(customer,new List<int>(),0);
       Console.WriteLine(carId);
    }

    public void GetIdFrom(int start, List<int> traveled,int currentDistance)
    {
        int id;
        if (currentDistance>minimal)
            return;
        if (CarLocations.TryGetValue(start,out id))
        {        
            if (currentDistance==minimal)
            {
                  if (id<carId)
                    carId=id;
            }
            if ( currentDistance<minimal)
            {
             
                minimal=currentDistance;
                  carId=id;
            }
            return;
        }
        id=Int32.MaxValue;;
         IEnumerable<Edge> startEdges=Edges.Where(x=>x.IsConnectedTo(start));
        List<int> currentTraveled=new List<int>(traveled);
        currentTraveled.Add(start);
        foreach(Edge e in startEdges)
        {
            int dest=e.FromGoTo(start);
            if (currentTraveled.Contains(dest)==false)
            {
              GetIdFrom(dest,currentTraveled,currentDistance+e.Length);
            }
        }
    }
}