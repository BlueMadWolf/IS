#include <iostream>
#include <vector>
#include <string>
#include <numeric>
#include <queue>
#include <list>
#include <set>
#include <ctime>

using namespace std;

struct barley_break
{
	barley_break * parent;
	vector<int> positions;
	int g; 
	int h;

	barley_break(vector<int> v, barley_break * par = nullptr) : parent(par), positions(v) 
	{ 
		if (par == nullptr)
			g = 0;
		else
			g = par->g + 1;
		h = heuristic();
	}
	
	int f() { return h + g; }

private:

	int Manhattan_distance(int start_ind)
	{
		int res = 0;
		int goal_ind = this->positions[start_ind] - 1;
		if (positions[start_ind] == 0)
			goal_ind = 15;
		return abs(start_ind % 4 - goal_ind % 4) + abs(start_ind / 4 - goal_ind / 4);
	}

	//Линейный конфликт
	int linear_conflict()
	{
		int cnt_conflict = 0; //число найденных конфликтов

		for(int i = 0; i < 16; ++i)
			if (positions[i] != 0)
			{
				int j = i + 1;
				while (j % 4 > i % 4)
				{
					if (positions[i] > positions[j] && (positions[i] - 1) / 4 == (positions[j] - 1) / 4 && positions[j] != 0)
						cnt_conflict++;
					j++;
				}

			}
		return 2*cnt_conflict;
	}

	//манъеттонское по всем + линейный конфликт
	int  heuristic()
	{
		int s = 0;
		for (int i = 0; i < 16; ++i)
			s += this->Manhattan_distance(i);

		return s + linear_conflict();
	}

	//находим позицию 0я
	int find_zero()
	{
		for (int i = 0; i < 16; ++i)
			if (positions[i] == 0)
				return i;
	}

	//создает новую позицию с перестановкой 0я
	barley_break * step(int old_zero, int new_zero)
	{
		vector<int> v = positions;
		swap(v[old_zero], v[new_zero]);
		return new barley_break(v, this);
	}

public:
	//определяем новые позиции
	list<barley_break *> neighbours()
	{
		list<barley_break *> res;
		barley_break * b;

		int current = this->find_zero();
		if (current % 4 != 0)
		{
			b = this->step(current, current - 1);
			if (this->parent == nullptr || b->positions != this->parent->positions)
				res.push_back(b);
		}
		if (current % 4 != 3)
		{
			b = this->step(current, current + 1);
			if (this->parent == nullptr || b->positions != this->parent->positions)
				res.push_back(b);
		}
		if (current / 4 != 0)
		{
			b = this->step(current, current - 4);
			if (this->parent == nullptr || b->positions != this->parent->positions)
				res.push_back(b);
		}
		if (current / 4 != 3)
		{
			b = this->step(current, current + 4);
			if (this->parent == nullptr || b->positions != this->parent->positions)
				res.push_back(b);
		}
		return res;
	}

	//печать матрицы на консоль
	void printMatrix()
	{
		for (int i = 0; i < 16; ++i)
		{
			if (i % 4 == 0)
				cout << endl;
			cout << this->positions[i] << ' ';
			if (this->positions[i] / 10 == 0) //чтобы выровнять столбцы
				cout << ' ';
		}
	}
};

//полученная начальная позиция
barley_break * start;

//проверка существования решения
bool verificationExSolution()
{
	int e; //номер ряда пустой клетки от 1
	vector<int> ni (15, 0); //кол-во меньшеих квадратиков, расположенных после iго

	for (int i = 15; i >= 0; --i)
		if (start->positions[i] == 0)
			e = i / 4 + 1;
		else
		{
 			for (int j = 15; j > i; --j)
				if (start->positions[j] < start->positions[i] && start->positions[j] != 0)
					ni[start->positions[i] - 1]++;
		}

	return (accumulate(ni.begin(), ni.end(), 0) + e) % 2 == 0;
}

//компаратор для очереди с приоритетом
struct cmp
{
	bool operator()(const barley_break * b1, const barley_break * b2) const { return b1->h + b1->g > b2->h + b2->g; }
};


set<vector<int>> u;

barley_break * A_star(barley_break * start, vector<int> goal)
{
	priority_queue<barley_break *, deque<barley_break*>, cmp> q;
	
	
	q.push(start); 
	
	while (!q.empty())
	{
		barley_break * current = q.top();
		q.pop();
		if (current->positions == goal)
		{
			while (!q.empty())
			{
				barley_break * b = q.top();
				delete b;
				q.pop();
			}
			return current;// нашли путь до нужной вершины
		}
		u.insert(current->positions);

		for (auto v : current->neighbours())     
			   if (u.find(v->positions) == u.end() || current->f() > v->f())
				   q.push(v);
			   else delete v;
	}
		
	return nullptr;

}

barley_break * solved_A()
{
	vector<int> goal(16);
	for (int i = 0; i < 15; ++i)
			goal[i] = i + 1;
	goal[15] = 0;

	barley_break * b = A_star(start, goal);
	
	/*auto it = u.begin();
	while (it != u.end())
		u.erase(it++);
	*/
	return b;
}

//разварачиваем решение и печатаем позиции с первой
void print_path(barley_break * b, time_t t)
{
	time_t end = clock();

	list<barley_break * > l;
	l.push_front(b);

	int cnt = 0; //кол-во полученных позиций за всю игру, начиная с заданной

	barley_break * p = b->parent;
	while (p != nullptr)
	{
		l.push_front(p);
		p = p -> parent;
	}

	for (auto e : l)
	{
		e->printMatrix();
		cnt++;
		if (e != start)
			delete e;
		cout << endl;
	}

	cout << "steps: " << cnt - 1 << "   time: " << (double)(end - t) / CLOCKS_PER_SEC << endl << endl;
}

//алгоритм поиска для А*
int search_ida(barley_break * b, int g, int bound, vector<int> goal, barley_break ** res)
{
	int f = g + b->h;

	if (f > bound)  
		return f;
	
	if (b->positions == goal)
	{
		*res = b;
		return -1; // флаг результата
	}

	int min = INT32_MAX;

	for (auto v : b->neighbours())
	{
		int t = search_ida(v, g + 1, bound, goal, res);
		if (t == -1) 
			return -1;
		if (t < min) min = t;
		delete v;
	}

	return min;
}

barley_break * ida_star(barley_break * start, vector<int> goal)
{
	barley_break * res = nullptr;
	int bound = start->h;
	int t = 0;

	while (t != INT32_MAX)
	{
		int t = search_ida(start, 0, bound, goal, &res); // вызов поиска
		if (t == -1)
			return res;
		bound = t;
	}

	return res;
}

barley_break * solved_ida()
{
	vector<int> goal(16);
	for (int i = 0; i < 15; ++i)
		goal[i] = i + 1;
	goal[15] = 0;

	return ida_star(start, goal);
}

//ввод данных
void inputData()
{
	string initial_position;
	cin >> initial_position;
	//initial_position = "12349560EDA7FC8B";  //"143256C89AB7DEF0"; // "12345670D9A8ECBF"; //"12345678A90BCFDE";"12349560EDA7FC8B";  
	vector<int> positions(16);

	for (int i = 0; i < 16; ++i)
		if (isdigit(initial_position[i]))
			positions[i] = initial_position[i] - '0';
		else
			if ('A' <= initial_position[i] && initial_position[i] <= 'F')
				positions[i] = initial_position[i] - 'A' + 10;
			else
				throw "Неверные входные данные";

	start = new barley_break(positions, nullptr);
}

int main()
{
	inputData();
	if (!verificationExSolution())
		cout << "It is impossible to find a solution." << endl;
	else
	{
		time_t s = clock();
		
		barley_break * end = solved_A();
		if (end != nullptr)
		{
			cout << endl << "A*: " << endl;
			print_path(end, s);
		}

		s = clock();
		end  = solved_ida();
		if (end != nullptr)
		{
			cout << "------------------------------" << endl << "IDA*: " << endl;
			print_path(end, s);
		}
	

	}
	system("Pause");
}
//12345670D9A8ECBF - 14
//162350749AB8DEFC - 6
//12349560EDA7FC8B - 20
//12345678A90BCFDE - 26
//143256C89AB7DEF0 - 24
//A64D8B3915EC02F7 - 51
/*
1234567890BCDAFE
It is impossible to find a solution.



12345678A90BCFDE

A*:

1  2  3  4
5  6  7  8
10 9  0  11
12 15 13 14

1  2  3  4
5  6  7  8
10 9  13 11
12 15 0  14

1  2  3  4
5  6  7  8
10 9  13 11
12 0  15 14

1  2  3  4
5  6  7  8
10 0  13 11
12 9  15 14

1  2  3  4
5  6  7  8
0  10 13 11
12 9  15 14

1  2  3  4
5  6  7  8
12 10 13 11
0  9  15 14

1  2  3  4
5  6  7  8
12 10 13 11
9  0  15 14

1  2  3  4
5  6  7  8
12 0  13 11
9  10 15 14

1  2  3  4
5  6  7  8
12 13 0  11
9  10 15 14

1  2  3  4
5  6  7  8
12 13 15 11
9  10 0  14

1  2  3  4
5  6  7  8
12 13 15 11
9  0  10 14

1  2  3  4
5  6  7  8
12 0  15 11
9  13 10 14

1  2  3  4
5  6  7  8
0  12 15 11
9  13 10 14

1  2  3  4
5  6  7  8
9  12 15 11
0  13 10 14

1  2  3  4
5  6  7  8
9  12 15 11
13 0  10 14

1  2  3  4
5  6  7  8
9  12 15 11
13 10 0  14

1  2  3  4
5  6  7  8
9  12 15 11
13 10 14 0

1  2  3  4
5  6  7  8
9  12 15 0
13 10 14 11

1  2  3  4
5  6  7  8
9  12 0  15
13 10 14 11

1  2  3  4
5  6  7  8
9  0  12 15
13 10 14 11

1  2  3  4
5  6  7  8
9  10 12 15
13 0  14 11

1  2  3  4
5  6  7  8
9  10 12 15
13 14 0  11

1  2  3  4
5  6  7  8
9  10 12 15
13 14 11 0

1  2  3  4
5  6  7  8
9  10 12 0
13 14 11 15

1  2  3  4
5  6  7  8
9  10 0  12
13 14 11 15

1  2  3  4
5  6  7  8
9  10 11 12
13 14 0  15

1  2  3  4
5  6  7  8
9  10 11 12
13 14 15 0
steps: 26   time: 0.01

--------------------------
IDA*:

1  2  3  4
5  6  7  8
10 9  0  11
12 15 13 14

1  2  3  4
5  6  7  8
10 9  13 11
12 15 0  14

1  2  3  4
5  6  7  8
10 9  13 11
12 0  15 14

1  2  3  4
5  6  7  8
10 0  13 11
12 9  15 14

1  2  3  4
5  6  7  8
0  10 13 11
12 9  15 14

1  2  3  4
5  6  7  8
12 10 13 11
0  9  15 14

1  2  3  4
5  6  7  8
12 10 13 11
9  0  15 14

1  2  3  4
5  6  7  8
12 0  13 11
9  10 15 14

1  2  3  4
5  6  7  8
12 13 0  11
9  10 15 14

1  2  3  4
5  6  7  8
12 13 15 11
9  10 0  14

1  2  3  4
5  6  7  8
12 13 15 11
9  0  10 14

1  2  3  4
5  6  7  8
12 0  15 11
9  13 10 14

1  2  3  4
5  6  7  8
0  12 15 11
9  13 10 14

1  2  3  4
5  6  7  8
9  12 15 11
0  13 10 14

1  2  3  4
5  6  7  8
9  12 15 11
13 0  10 14

1  2  3  4
5  6  7  8
9  12 15 11
13 10 0  14

1  2  3  4
5  6  7  8
9  12 15 11
13 10 14 0

1  2  3  4
5  6  7  8
9  12 15 0
13 10 14 11

1  2  3  4
5  6  7  8
9  12 0  15
13 10 14 11

1  2  3  4
5  6  7  8
9  0  12 15
13 10 14 11

1  2  3  4
5  6  7  8
9  10 12 15
13 0  14 11

1  2  3  4
5  6  7  8
9  10 12 15
13 14 0  11

1  2  3  4
5  6  7  8
9  10 12 15
13 14 11 0

1  2  3  4
5  6  7  8
9  10 12 0
13 14 11 15

1  2  3  4
5  6  7  8
9  10 0  12
13 14 11 15

1  2  3  4
5  6  7  8
9  10 11 12
13 14 0  15

1  2  3  4
5  6  7  8
9  10 11 12
13 14 15 0
steps: 26   time: 0.011



143256C89AB7DEF0

A*:

1  4  3  2
5  6  12 8
9  10 11 7
13 14 15 0

1  4  3  2
5  6  12 8
9  10 11 7
13 14 0  15

1  4  3  2
5  6  12 8
9  10 0  7
13 14 11 15

1  4  3  2
5  6  12 8
9  0  10 7
13 14 11 15

1  4  3  2
5  0  12 8
9  6  10 7
13 14 11 15

1  0  3  2
5  4  12 8
9  6  10 7
13 14 11 15

1  3  0  2
5  4  12 8
9  6  10 7
13 14 11 15

1  3  2  0
5  4  12 8
9  6  10 7
13 14 11 15

1  3  2  8
5  4  12 0
9  6  10 7
13 14 11 15

1  3  2  8
5  4  0  12
9  6  10 7
13 14 11 15

1  3  2  8
5  0  4  12
9  6  10 7
13 14 11 15

1  0  2  8
5  3  4  12
9  6  10 7
13 14 11 15

1  2  0  8
5  3  4  12
9  6  10 7
13 14 11 15

1  2  4  8
5  3  0  12
9  6  10 7
13 14 11 15

1  2  4  8
5  0  3  12
9  6  10 7
13 14 11 15

1  2  4  8
5  6  3  12
9  0  10 7
13 14 11 15

1  2  4  8
5  6  3  12
9  10 0  7
13 14 11 15

1  2  4  8
5  6  3  12
9  10 7  0
13 14 11 15

1  2  4  8
5  6  3  0
9  10 7  12
13 14 11 15

1  2  4  0
5  6  3  8
9  10 7  12
13 14 11 15

1  2  0  4
5  6  3  8
9  10 7  12
13 14 11 15

1  2  3  4
5  6  0  8
9  10 7  12
13 14 11 15

1  2  3  4
5  6  7  8
9  10 0  12
13 14 11 15

1  2  3  4
5  6  7  8
9  10 11 12
13 14 0  15

1  2  3  4
5  6  7  8
9  10 11 12
13 14 15 0
steps: 24   time: 0.03

------------------------------
IDA*:

1  4  3  2
5  6  12 8
9  10 11 7
13 14 15 0

1  4  3  2
5  6  12 8
9  10 11 7
13 14 0  15

1  4  3  2
5  6  12 8
9  10 0  7
13 14 11 15

1  4  3  2
5  6  12 8
9  0  10 7
13 14 11 15

1  4  3  2
5  0  12 8
9  6  10 7
13 14 11 15

1  0  3  2
5  4  12 8
9  6  10 7
13 14 11 15

1  3  0  2
5  4  12 8
9  6  10 7
13 14 11 15

1  3  2  0
5  4  12 8
9  6  10 7
13 14 11 15

1  3  2  8
5  4  12 0
9  6  10 7
13 14 11 15

1  3  2  8
5  4  0  12
9  6  10 7
13 14 11 15

1  3  2  8
5  0  4  12
9  6  10 7
13 14 11 15

1  0  2  8
5  3  4  12
9  6  10 7
13 14 11 15

1  2  0  8
5  3  4  12
9  6  10 7
13 14 11 15

1  2  4  8
5  3  0  12
9  6  10 7
13 14 11 15

1  2  4  8
5  0  3  12
9  6  10 7
13 14 11 15

1  2  4  8
5  6  3  12
9  0  10 7
13 14 11 15

1  2  4  8
5  6  3  12
9  10 0  7
13 14 11 15

1  2  4  8
5  6  3  12
9  10 7  0
13 14 11 15

1  2  4  8
5  6  3  0
9  10 7  12
13 14 11 15

1  2  4  0
5  6  3  8
9  10 7  12
13 14 11 15

1  2  0  4
5  6  3  8
9  10 7  12
13 14 11 15

1  2  3  4
5  6  0  8
9  10 7  12
13 14 11 15

1  2  3  4
5  6  7  8
9  10 0  12
13 14 11 15

1  2  3  4
5  6  7  8
9  10 11 12
13 14 0  15

1  2  3  4
5  6  7  8
9  10 11 12
13 14 15 0
steps: 24   time: 0.014





A64D8B3915EC02F7

A*:

10 6  4  13
8  11 3  9
1  5  14 12
0  2  15 7

10 6  4  13
8  11 3  9
1  5  14 12
2  0  15 7

10 6  4  13
8  11 3  9
1  0  14 12
2  5  15 7

10 6  4  13
8  11 3  9
0  1  14 12
2  5  15 7

10 6  4  13
8  11 3  9
2  1  14 12
0  5  15 7

10 6  4  13
8  11 3  9
2  1  14 12
5  0  15 7

10 6  4  13
8  11 3  9
2  1  14 12
5  15 0  7

10 6  4  13
8  11 3  9
2  1  14 12
5  15 7  0

10 6  4  13
8  11 3  9
2  1  14 0
5  15 7  12

10 6  4  13
8  11 3  0
2  1  14 9
5  15 7  12

10 6  4  0
8  11 3  13
2  1  14 9
5  15 7  12

10 6  0  4
8  11 3  13
2  1  14 9
5  15 7  12

10 6  3  4
8  11 0  13
2  1  14 9
5  15 7  12

10 6  3  4
8  0  11 13
2  1  14 9
5  15 7  12

10 6  3  4
0  8  11 13
2  1  14 9
5  15 7  12

10 6  3  4
2  8  11 13
0  1  14 9
5  15 7  12

10 6  3  4
2  8  11 13
1  0  14 9
5  15 7  12

10 6  3  4
2  8  11 13
1  14 0  9
5  15 7  12

10 6  3  4
2  8  11 13
1  14 9  0
5  15 7  12

10 6  3  4
2  8  11 0
1  14 9  13
5  15 7  12

10 6  3  4
2  8  0  11
1  14 9  13
5  15 7  12

10 6  3  4
2  0  8  11
1  14 9  13
5  15 7  12

10 0  3  4
2  6  8  11
1  14 9  13
5  15 7  12

0  10 3  4
2  6  8  11
1  14 9  13
5  15 7  12

2  10 3  4
0  6  8  11
1  14 9  13
5  15 7  12

2  10 3  4
1  6  8  11
0  14 9  13
5  15 7  12

2  10 3  4
1  6  8  11
14 0  9  13
5  15 7  12

2  10 3  4
1  6  8  11
14 9  0  13
5  15 7  12

2  10 3  4
1  6  8  11
14 9  13 0
5  15 7  12

2  10 3  4
1  6  8  0
14 9  13 11
5  15 7  12

2  10 3  4
1  6  0  8
14 9  13 11
5  15 7  12

2  10 3  4
1  0  6  8
14 9  13 11
5  15 7  12

2  10 3  4
1  9  6  8
14 0  13 11
5  15 7  12

2  10 3  4
1  9  6  8
14 13 0  11
5  15 7  12

2  10 3  4
1  9  6  8
14 13 7  11
5  15 0  12

2  10 3  4
1  9  6  8
14 13 7  11
5  0  15 12

2  10 3  4
1  9  6  8
14 0  7  11
5  13 15 12

2  10 3  4
1  9  6  8
0  14 7  11
5  13 15 12

2  10 3  4
1  9  6  8
5  14 7  11
0  13 15 12

2  10 3  4
1  9  6  8
5  14 7  11
13 0  15 12

2  10 3  4
1  9  6  8
5  0  7  11
13 14 15 12

2  10 3  4
1  0  6  8
5  9  7  11
13 14 15 12

2  0  3  4
1  10 6  8
5  9  7  11
13 14 15 12

0  2  3  4
1  10 6  8
5  9  7  11
13 14 15 12

1  2  3  4
0  10 6  8
5  9  7  11
13 14 15 12

1  2  3  4
5  10 6  8
0  9  7  11
13 14 15 12

1  2  3  4
5  10 6  8
9  0  7  11
13 14 15 12

1  2  3  4
5  0  6  8
9  10 7  11
13 14 15 12

1  2  3  4
5  6  0  8
9  10 7  11
13 14 15 12

1  2  3  4
5  6  7  8
9  10 0  11
13 14 15 12

1  2  3  4
5  6  7  8
9  10 11 0
13 14 15 12

1  2  3  4
5  6  7  8
9  10 11 12
13 14 15 0
steps: 51   time: 51.075

-----------------------------
IDA*:

10 6  4  13
8  11 3  9
1  5  14 12
0  2  15 7

10 6  4  13
8  11 3  9
1  5  14 12
2  0  15 7

10 6  4  13
8  11 3  9
1  5  14 12
2  15 0  7

10 6  4  13
8  11 3  9
1  5  14 12
2  15 7  0

10 6  4  13
8  11 3  9
1  5  14 0
2  15 7  12

10 6  4  13
8  11 3  0
1  5  14 9
2  15 7  12

10 6  4  0
8  11 3  13
1  5  14 9
2  15 7  12

10 6  0  4
8  11 3  13
1  5  14 9
2  15 7  12

10 6  3  4
8  11 0  13
1  5  14 9
2  15 7  12

10 6  3  4
8  0  11 13
1  5  14 9
2  15 7  12

10 6  3  4
0  8  11 13
1  5  14 9
2  15 7  12

10 6  3  4
1  8  11 13
0  5  14 9
2  15 7  12

10 6  3  4
1  8  11 13
5  0  14 9
2  15 7  12

10 6  3  4
1  8  11 13
5  14 0  9
2  15 7  12

10 6  3  4
1  8  11 13
5  14 9  0
2  15 7  12

10 6  3  4
1  8  11 0
5  14 9  13
2  15 7  12

10 6  3  4
1  8  0  11
5  14 9  13
2  15 7  12

10 6  3  4
1  0  8  11
5  14 9  13
2  15 7  12

10 0  3  4
1  6  8  11
5  14 9  13
2  15 7  12

0  10 3  4
1  6  8  11
5  14 9  13
2  15 7  12

1  10 3  4
0  6  8  11
5  14 9  13
2  15 7  12

1  10 3  4
5  6  8  11
0  14 9  13
2  15 7  12

1  10 3  4
5  6  8  11
14 0  9  13
2  15 7  12

1  10 3  4
5  6  8  11
14 9  0  13
2  15 7  12

1  10 3  4
5  6  8  11
14 9  13 0
2  15 7  12

1  10 3  4
5  6  8  0
14 9  13 11
2  15 7  12

1  10 3  4
5  6  0  8
14 9  13 11
2  15 7  12

1  10 3  4
5  0  6  8
14 9  13 11
2  15 7  12

1  10 3  4
5  9  6  8
14 0  13 11
2  15 7  12

1  10 3  4
5  9  6  8
14 13 0  11
2  15 7  12

1  10 3  4
5  9  6  8
14 13 7  11
2  15 0  12

1  10 3  4
5  9  6  8
14 13 7  11
2  0  15 12

1  10 3  4
5  9  6  8
14 0  7  11
2  13 15 12

1  10 3  4
5  9  6  8
0  14 7  11
2  13 15 12

1  10 3  4
5  9  6  8
2  14 7  11
0  13 15 12

1  10 3  4
5  9  6  8
2  14 7  11
13 0  15 12

1  10 3  4
5  9  6  8
2  0  7  11
13 14 15 12

1  10 3  4
5  0  6  8
2  9  7  11
13 14 15 12

1  0  3  4
5  10 6  8
2  9  7  11
13 14 15 12

0  1  3  4
5  10 6  8
2  9  7  11
13 14 15 12

5  1  3  4
0  10 6  8
2  9  7  11
13 14 15 12

5  1  3  4
2  10 6  8
0  9  7  11
13 14 15 12

5  1  3  4
2  10 6  8
9  0  7  11
13 14 15 12

5  1  3  4
2  0  6  8
9  10 7  11
13 14 15 12

5  1  3  4
0  2  6  8
9  10 7  11
13 14 15 12

0  1  3  4
5  2  6  8
9  10 7  11
13 14 15 12

1  0  3  4
5  2  6  8
9  10 7  11
13 14 15 12

1  2  3  4
5  0  6  8
9  10 7  11
13 14 15 12

1  2  3  4
5  6  0  8
9  10 7  11
13 14 15 12

1  2  3  4
5  6  7  8
9  10 0  11
13 14 15 12

1  2  3  4
5  6  7  8
9  10 11 0
13 14 15 12

1  2  3  4
5  6  7  8
9  10 11 12
13 14 15 0
steps: 51   time: 64.069
*/