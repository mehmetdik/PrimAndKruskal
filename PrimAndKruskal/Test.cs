using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12253021HW4
{
    class Test
    {
        static void Main(string[] args)
        {

            string[] GraphLinesTxt = System.IO.File.ReadAllLines("Graph.txt");//Doyamızı oluşturduk.Dosyadaki bütün satırları diziye atadık
            Graph<int> myGraph = new Graph<int>();
            string vertexID = "";
            foreach (char karakter in GraphLinesTxt[0])   //ilk satırdakileri grapha ekledik.
            {
                if (karakter != ' ')
                    vertexID += karakter;
                else
                {
                    myGraph.addVertex(vertexID);
                    vertexID = "";
                }
            }
             for (int i = 1; i < GraphLinesTxt.Length; i++)  //Edgeleri ekledik.
            {
                string HomeVertexID = "";
                string VertexID = "";
                string weight = "";
                int Counter = 0;

                foreach (char karakter in GraphLinesTxt[i])
                {
                    if (karakter == ' ')  
                        Counter++;
                    if (karakter != ' ' && Counter == 0)                    
                        HomeVertexID += karakter;
                    else if (karakter != ' ' && Counter == 1)                    
                        VertexID += karakter;
                    else if (karakter != ' ' && Counter == 2)                    
                        weight += karakter;
                }


                if (HomeVertexID.Length != 0 && VertexID.Length != 0 && weight.Length != 0)
                {
                    myGraph.addEdge(HomeVertexID, VertexID, Convert.ToInt32(weight));
                }
            }
             Console.WriteLine("************************ Dosyadan Okunan GRAPH ****************************");
             myGraph.display();
             Graph<int> NewGraph;

             Console.WriteLine("\n************* Kruskal Algoritmasına Göre **********");
             NewGraph = myGraph.Kruskal();
             NewGraph.display();

           
            
            Console.WriteLine("\n********** Prims Algoritmasına Göre  ************");
             NewGraph = myGraph.PrimsAlgoritması();
             NewGraph.display();
             
        }
    }
}
