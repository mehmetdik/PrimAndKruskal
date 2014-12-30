using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12253021HW4
{
    class Graph<T> where T : IComparable
    {
        Vertex head;


        public Vertex createVertex(string id)
        {
            return new Vertex(id);
        }

        public Edge createEdge(string id, int weight, string HomeVertexId)
        {
            return new Edge(id, weight, HomeVertexId);
        }

        public Vertex findVertex(string id)
        {
            Vertex iterator = head;
            while (iterator != null)
            {
                if (iterator.Id == id)
                    return iterator;
                iterator = iterator.Next;
            }
            return null;
        }

        public bool searchVertex(string id)
        {
            Vertex iterator = head;
            while (iterator != null)
            {
                if (iterator.Id.CompareTo(id) == 0)
                    return true;
                iterator = iterator.Next;
            }
            return false;
        }

        public bool searchEdge(string id, Vertex current)
        {
            Vertex iterator = current;
            Edge edgeiterator = iterator.EdgeLink;
            while (edgeiterator != null)
            {
                if (edgeiterator.VertexId.CompareTo(id) == 0)
                    return true;
                edgeiterator = edgeiterator.Next;
            }
            return false;
        }

        public int vertexCount()
        {
            int counter = 0;
            Vertex iterator = head;
            while (iterator != null)
            {
                counter++;
                iterator = iterator.Next;
            }
            return counter;
        }

        public void addVertex(string id)
        {
            Vertex iterator = head;
            if (head == null)
            {
                head = createVertex(id);
            }
            else
            {
                if (!searchVertex(id))
                {
                    while (iterator.Next != null)
                    {
                        iterator = iterator.Next;
                    }
                    iterator.Next = createVertex(id);
                }
            }
        }

        public void addEdge(string startId, string endId, int weight)
        {
            if (searchVertex(startId) && searchVertex(endId))
            {
                Vertex myVertex = findVertex(startId);
                Edge edgeIterator = myVertex.EdgeLink;
                if (edgeIterator == null)
                {
                    myVertex.EdgeLink = createEdge(endId, weight, startId);
                }
                else
                {
                    if (!searchEdge(endId, myVertex))
                    {
                        while (edgeIterator.Next != null)
                        {
                            edgeIterator = edgeIterator.Next;
                        }
                        edgeIterator.Next = createEdge(endId, weight, startId);
                    }
                }
            }
        }
        public void display()
        {
            Vertex iterator = head;
            while (iterator != null)
            {
                Console.Write(iterator.ToString() + " --> ");
                Edge iteratorEdge = iterator.EdgeLink;
                while (iteratorEdge != null)
                {
                    Console.Write(iteratorEdge.ToString() + " " + iteratorEdge.Weight.ToString() + "   ");
                    iteratorEdge = iteratorEdge.Next;
                }
                Console.WriteLine();
                iterator = iterator.Next;
            }
            Console.WriteLine();
        }

        public int outdegree(string id)
        {
            Vertex current = findVertex(id);
            if (current != null)
            {
                int counter = 0;
                Edge iterator = current.EdgeLink;
                while (iterator != null)
                {
                    counter++;
                    iterator = iterator.Next;
                }
                return counter;
            }
            return -1;
        }
      

        public int indegree(string id)
        {
            Vertex iterator = head;
            int count = 0;
            while (iterator != null)
            {
                Edge edgeiterator = iterator.EdgeLink;
                while (edgeiterator != null)
                {
                    if (id == edgeiterator.VertexId)
                    {
                        count++;
                    }
                    edgeiterator = edgeiterator.Next;
                }

                iterator = iterator.Next;
            }
            return count;
        }

        //komşuluk matrisi bulalım

        public int findIndex(string id)
        {
            Vertex iterator = head;
            int count = 0;
            while (iterator != null)
            {
                if (iterator.Id == id)
                {
                    return count;
                }
                count++;
                iterator = iterator.Next;
            }
            return -1;
        }

        public int[,] adjacencyMatrix()
        {
            int size = vertexCount();
            int[,] matrix = new int[size, size];
            Vertex iterator = head;
            while (iterator != null)
            {
                matrix[findIndex(iterator.Id), findIndex(iterator.EdgeLink.VertexId)] = 1;
            }
            return matrix;
        }
        public Graph<T> copyGraph()
        {
            Graph<T> newGraph = new Graph<T>();
            Vertex iterator = head;
            Vertex otheriterator = head;
            while (iterator != null)
            {
                newGraph.addVertex(iterator.Id);
                iterator = iterator.Next;
            }
            iterator = head;
            while (iterator != null)
            {
                Edge edgeIterator = iterator.EdgeLink;
                while (edgeIterator != null)
                {
                    newGraph.addEdge(iterator.Id, edgeIterator.VertexId, edgeIterator.Weight);
                    edgeIterator = edgeIterator.Next;
                }
                iterator = iterator.Next;
            }

            return newGraph;
        }

        public int EdgeCount()
        {
            int counter = 1;
            Vertex iterator = head;

            while (iterator != null)
            {
                while (iterator.EdgeLink != null)
                {
                    counter++;
                    iterator.EdgeLink = iterator.EdgeLink.Next;
                }

                iterator = iterator.Next;
            }
            return counter;
        }

        

        public Edge[] KruskalArray()//Graphdaki edgeleri diziye atar.
        {

            Graph<T> CopyKruskal = copyGraph();
            Vertex iterator = CopyKruskal.head;
            Edge[] ArrayEdge = new Edge[EdgeCount()-1];

            int i = 0;
            while (iterator != null)
            {
                while (iterator.EdgeLink != null)
                {

                    ArrayEdge[i] = iterator.EdgeLink;
                    iterator.EdgeLink = iterator.EdgeLink.Next;
                    i++;

                }
                iterator = iterator.Next;
            }
            return ArrayEdge;

        }
        public Edge[] EdgeSort()//Edge leri sıralayıp diziye atar diziyi dönderir.
        {
            
            Edge[] Array = KruskalArray();
            Edge gecici;
            for (int i = 0; i < Array.Length - 1; i++)
            {
                for (int j = 1; j < Array.Length - 1; j++)
                {
                    if (Array[j - 1].Weight.CompareTo(Array[j].Weight) == 1)
                    {
                        gecici = Array[j - 1];
                        Array[j - 1] = Array[j];
                        Array[j] = gecici;
                    }
                }
            }
            return Array;
        }

        public Graph<T> Kruskal()
        {
            Graph<T> KruskalGraph = new Graph<T>();
            Edge[] ArraySort = EdgeSort();
            Vertex[] ArrayVertex = new Vertex[vertexCount()];
            LinkedList<String> ListVertex = new LinkedList<String>();
            for (int i = 0; i < ArraySort.Length; i++)
            {
                if (i == 0)//ilk iki vertex için
                {
                    KruskalGraph.addVertex(ArraySort[i].HomeVertexId);
                    KruskalGraph.addVertex(ArraySort[i].VertexId);
                    KruskalGraph.addEdge(ArraySort[i].HomeVertexId, ArraySort[i].VertexId, ArraySort[i].Weight);

                    ListVertex.addToEnd(ArraySort[i].HomeVertexId);
                    ListVertex.addToEnd(ArraySort[i].VertexId);


                }
                else
                {
                    if (!(ListVertex.search(ArraySort[i].VertexId) && ListVertex.search(ArraySort[i].HomeVertexId)))//iki vertex'De ziyaret edilmemişse iki vertexide grapha ekler
                    {
                        KruskalGraph.addVertex(ArraySort[i].VertexId);
                        KruskalGraph.addVertex(ArraySort[i].HomeVertexId);
                        ListVertex.addToEnd(ArraySort[i].VertexId);
                        ListVertex.addToEnd(ArraySort[i].HomeVertexId);
                        KruskalGraph.addEdge(ArraySort[i].HomeVertexId, ArraySort[i].VertexId, ArraySort[i].Weight);

                    }
                    if (!(ListVertex.search(ArraySort[i].VertexId)) && ListVertex.search(ArraySort[i].HomeVertexId))//sadece biri ziyaret edilmemişse ziyaret edilmeyeni ekler
                    {
                        KruskalGraph.addVertex(ArraySort[i].VertexId);
                        ListVertex.addToEnd(ArraySort[i].VertexId);
                        KruskalGraph.addEdge(ArraySort[i].HomeVertexId, ArraySort[i].VertexId, ArraySort[i].Weight);
                    }
                    if (ListVertex.search(ArraySort[i].VertexId) && !(ListVertex.search(ArraySort[i].HomeVertexId)))//sadece biri ziyaret edilmemişse ziyaret edilmeyeni ekler
                    {
                        KruskalGraph.addVertex(ArraySort[i].HomeVertexId);
                        ListVertex.addToEnd(ArraySort[i].HomeVertexId);

                        KruskalGraph.addEdge(ArraySort[i].HomeVertexId, ArraySort[i].VertexId, ArraySort[i].Weight);

                    }


                }
            }

            return KruskalGraph;
        }






        public void deleteEdge(Edge edge,Graph<T> Copy)//Minimum edgeleri silmeye yarayan fonksiyon
        {
            Vertex TempVertex = Copy.findVertex(edge.HomeVertexId);

            if (TempVertex != null)
            {
                Edge iterator = TempVertex.EdgeLink;
                Edge previous = TempVertex.EdgeLink.Next;
                if (iterator != null)
                {
                    if (iterator.VertexId.Equals(edge.VertexId))//iteratorun ıdi si ile edgein vertexinin ıd'sini karşılaştırdık
                    {
                        iterator = iterator.Next;

                    }
                    else
                    {
                        while (previous != null)
                        {
                            if (previous.VertexId.Equals(edge.VertexId))
                            {
                                iterator.Next = previous.Next;
                            }
                            previous = previous.Next;
                            iterator = iterator.Next;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("hata");
                }
            }
            else
            {
                Console.WriteLine("Uygunsuz");
            }


        }

      
        
        public Graph<T> PrimsAlgoritması()
        {
            Graph<T> Copy = copyGraph();
            int countEdge = Copy.EdgeCount();
            Queue<String> VertexQueue = new Queue<String>(vertexCount());
            Queue<Edge> MinEdgeQueue = new Queue<Edge>(countEdge);
            
            
            
            Graph<T> PrimsGraph = new Graph<T>();//Prims algoritması sonucu olucan yeni graph
            Edge[] EdgeLink = new Edge[countEdge];//Edge'leri içinde tutması için oluşturduğumuz Edge dizisi.
            int count = 0, i = 0;
            Vertex TempVertex;
            
            Edge Min = Copy.head.EdgeLink;//Kopya grafımızın head vertexinin edge'ini Min değişkenine attık.Minimum olarak kabul ettik
            int count2 = 0;
            Edge iterator = Copy.head.EdgeLink;
            while (countEdge != count2)//Edege kadar döner
            {
                count2++;
                if (count == 0)//ilk iki vertex için yapılan işlemler burdan başlar
                {
                    VertexQueue.enQueue(Copy.head.Id);//Verex Queue'sine kopya graphın vertexinin ıd atıldı
                    PrimsGraph.addVertex(Copy.head.Id);//bu vertex grapha eklendi



                    while (iterator != null)//iterator null  olana kadar döner
                    {
                        EdgeLink[i] = Copy.head.EdgeLink;//Diziye edge leri atarız
                        iterator = iterator.Next;//iteratoru ilerlettik
                        i++;
                    }
                    for (int j = 1; j < EdgeLink.Length; j++)//dizi boyutu kadar döner
                    {
                        if (Min.Weight.CompareTo(EdgeLink[j].Weight) == 1)//Minimum değişkeninin ağırlığı ile dizideki değişkenin ağırşığını karşılaştırdık
                        {
                            Min = EdgeLink[j];
                        }
                    }
                    MinEdgeQueue.enQueue(Min);
                    PrimsGraph.addVertex(Min.VertexId);//Yeni Grapha vertexi ekledik
                    PrimsGraph.addEdge(head.Id, Min.VertexId, Min.Weight);//edgelinki oluşturduk
                    VertexQueue.enQueue(Min.VertexId);
                    deleteEdge(Min,Copy);//Üzerinden geçtiğimiz edgelinki sildik graphdan
                    count++;
                   // iterator=iterator.Next;
                }

                else//İlk iki vertex hariç diğer vertexler için yapılıcak işlemler burdan başlar
                {
                    Edge[] edgeDizi = new Edge[EdgeCount()];//dizi oluşturduk
                    int z = 0;
                    for (int k = 0; k < VertexQueue.size(); k++)
                    {
                        TempVertex = findVertex(VertexQueue.deQueue());//Qeue'Den vertexi çıkardık find ile bulduk onu değişkene eşitledik.
                        while (TempVertex.EdgeLink != null)
                        {
                            edgeDizi[z] = TempVertex.EdgeLink;//Edgelinki diziye ekledik
                            z++;
                            TempVertex.EdgeLink = TempVertex.EdgeLink.Next;//Değişkenin edgelinikini ilerlettik
                        }
                        VertexQueue.enQueue(TempVertex.Id);
                    }
                    Min = edgeDizi[0];
                    for (int t = 1; t < edgeDizi.Length; t++)
                    {
                        if (Min.Weight > edgeDizi[t].Weight)
                        {
                            Min = edgeDizi[t];
                        }
                    }

                    PrimsGraph.addVertex(Min.VertexId);//grapha vertexi ekledik.
                    PrimsGraph.addEdge(Min.HomeVertexId, Min.VertexId, Min.Weight);//edge ekledik
                    Copy.deleteEdge(Min,Copy);//edgeyi sildik

                }

            }
            return PrimsGraph;
        }
    }
}
