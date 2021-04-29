Простая реализация __алгоритма Дейкстры по нахождению кратчайшего пути__.

1. **Чтобы установить и запустить приложение скопируйте и вставте в терминал.**
 ```
 git clone https://github.com/q00Dree/dijkstra-algorithm.git \
 && cd dijkstra-algorithm \
 && cd src \
 && cd DijkstraImplementation.EntryPoint \
 && dotnet run
 ```

2. **В приложении, а именно в модуле ```DijkstraImplementation.EntryPoint``` уже введена матрица следующего графа.**

![Задание для Варианта 18 Сафиуллин](https://github.com/q00Dree/dijkstra-algorithm/blob/master/docs/task_for_18_updated.jpg)

```csharp
int[,] graph = new[,]
{
                        /*1*/  /*2*/   /*3*/   /*4*/   /*5*/   /*6*/   /*7*/   /*8*/
              /*1*/   {   0,     2,      3,      8,      0,      0,      0,      0   }, 
              /*2*/   {   2,     0,      0,      2,      0,      1,      0,      0   }, 
              /*3*/   {   3,     0,      0,      5,      0,      6,      0,      3   }, 
              /*4*/   {   8,     2,      5,      0,      3,      5,      0,      0   }, 
              /*5*/   {   0,     0,      0,      3,      0,      6,      0,      7   }, 
              /*6*/   {   0,     1,      6,      5,      6,      0,      12,     8   }, 
              /*7*/   {   0,     0,      0,      0,      0,      12,     0,      5   }, 
              /*8*/   {   0,     0,      3,      0,      7,      8,      5,      0   }, 
};
 ```


3. **Вывод приложения.**

![Вывод программы для Варианта 18 Сафиуллин](https://github.com/q00Dree/dijkstra-algorithm/blob/master/docs/output_for_18.jpg)

4. **Для поиска путей к своему графу нужно ввести матрицу в массив  ```graph``` и задать нужные вершины в методе ```PrintPath```.**
