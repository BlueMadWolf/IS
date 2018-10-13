#include <iostream>
#include <vector>
#include <list>
#include <algorithm>
#include <string>

using namespace std;

int steps;
int proc;

struct border
{
	vector<int> positions;
	bool exMutation;
	int suit;

	border(vector<int> v, bool mut) : positions(v), exMutation(mut)
	{ 
		good_pos.resize(8, true); 

		if (exMutation)
		{
			//mutation();
			suit = suitability();
			control_mutation();
		}
			

		suit = suitability();
	}

private:
	bool non_attacking_pair(int i, int j)
	{
		if (positions[i] == positions[j])
			return false;

		int cnt = 0;
		if (i > j)
		{
			int pos = i;
			while (pos > j)
			{
				pos--;
				cnt++;
			}
		}
		else
		{
			int pos = i;
			while (pos < j)
			{
				pos++;
				cnt++;
			}
		}

		return cnt != abs(positions[i] - positions[j]);
	}

	//для контроля мутации
	vector<bool> good_pos;

	//функция пригодности
	int suitability()
	{
		int cnt = 0;

		for (int i = 0; i < 7; ++i)
			for (int j = i + 1; j < 8; ++j)
				if (non_attacking_pair(i, j))
					cnt++;
				else
				{
					good_pos[i] = false;
					good_pos[j] = false;
				}
			

		return cnt;
	}

	//мутация
	void mutation()
	{
		if (rand() % 1)
		{
			positions[rand() % 7] = rand() % 8 + 1;
		}
	}

	void control_mutation()
	{
		if (rand() % 2)
		{
			int pos = rand() % 7;
			while (good_pos[pos])
				pos = rand() % 7;
			positions[pos] = rand() % 8 + 1;
		}
	}

public:
	pair<border *, border *> childs(border * other_parent)
	{
		int del = rand() % 6 + 1;
		vector<int> child_pos1(8);
		vector<int> child_pos2(8);

		for (int i = 0; i < del; ++i)
		{
			child_pos1[i] = this->positions[i];
			child_pos2[i] = other_parent->positions[i];
		}
		for (int i = del; i < 8; ++i)
		{
			child_pos2[i] = this->positions[i];
			child_pos1[i] = other_parent->positions[i];
		}

		return pair<border*, border *>(new border(child_pos1, true), new border(child_pos2, true));
	}

	bool operator=(border b)
	{
		positions = b.positions;
		exMutation = b.exMutation;
		good_pos = b.good_pos;
	}

	int count_good_pos()
	{
		return count(good_pos.begin(), good_pos.end(), true);
	}
};

border * answer;

bool is_goal(border * b)
{
	int f = 0;
	for (int i = 0; i < 7; ++i)
		for(int j = i + 1; j < 8; ++j)
			f++;
	return b->suit == f;
}

struct comp
{
	bool operator()(border * b1, border * b2) { return b1->suit > b2->suit; }
};


//будем считать, что очередь отсортирована
bool selection(vector<border * > & v)
{
	bool change = false;

	for (int i = v.size() - 1; i >= v.size() - 1 - proc; i -= 2)
	{
		int ind_p = rand() % (v.size() - 2 - proc);
		int ind2 = rand() % (v.size() - 2 - proc);

		while (ind2 == ind_p)
			ind2 = rand() % (v.size() - 1 - proc);
		auto p = v[ind_p]->childs(v[ind2]);

		if (is_goal(p.first))
		{
			answer = p.first;
			return true;
		}

		if (is_goal(p.second))
		{
			answer = p.second;
			return true;
		}

		//добавим модификацию - если пригодность дочернего хуже, то не добавляем его
		if (p.first->suit >= v[i]->suit || p.first->count_good_pos() > v[i]->count_good_pos())
		{
			v[i] = p.first;
			change = true;
		}
		if (p.second->suit >= v[i - 1]->suit || p.second->count_good_pos() > v[i-1]->count_good_pos())
		{
			v[i - 1] = p.second;
			change = true;
		}
	}

	return change;
}
vector<border *> generate_v(int num)
{
	steps = 0;
	answer = nullptr;

	vector<border *> v_b(num);
	vector<int> v(8);

	for (int i = 0; i < num; ++i)
	{
		for (int i = 0; i < 8; ++i)
			v[i] = rand() % 8 + 1;
		v_b[i] = new border(v, false);
	}

	return v_b;
}

void print_answer()
{
	vector<string> res(10);
	res[0] = "_________________";
	res[9] = "_________________";

	for (int i = 1; i < 9; ++i)
		res[i] = to_string(i) + "|_|_|_|_|_|_|_|_|";

	if (answer != nullptr)
	{
		cout << "Количество шагов: " << steps << endl;
		cout << "Полученная позиция: " << endl;
		
		for (int i = 0; i < 8; ++i)
			res[answer->positions[i]][i*2 + 2] = '*';

		for (int i = 0; i < 10; ++i)
			cout << res[i] << endl;
	}
}

int main()
{
	setlocale(LC_ALL, "Russian");
	cout << "Введите кол-во экземпляров (k): ";
	int k;
	cin >> k;
	RAND_MAX;

	vector<border *> v = generate_v(k);

	cout << "Введите кол-во выбрасываемых случаев (1-(k-2)): ";
	cin >> proc;

	while (answer == nullptr)
	{
		sort(v.begin(), v.end(), comp());
		//cout << v[0]->suit << endl;
		while(!selection(v)) {}

		steps++;

		if (steps % 1000 == 0)
		{
			cout << v[0]->suit << endl;
			system("Pause");
		}
	}

	print_answer();
	system("Pause");
}
/*
Введите кол-во экземпляров (k): 80
Введите кол-во выбрасываемых случаев (1-(k-2)): 55
Количество шагов: 27
Полученная позиция:
_________________
1|_|_|_|_|_|*|_|_|
2|_|*|_|_|_|_|_|_|
3|_|_|_|_|_|_|*|_|
4|*|_|_|_|_|_|_|_|
5|_|_|*|_|_|_|_|_|
6|_|_|_|_|*|_|_|_|
7|_|_|_|_|_|_|_|*|
8|_|_|_|*|_|_|_|_|
_________________



Введите кол-во экземпляров (k): 100
Введите кол-во выбрасываемых случаев (1-(k-2)): 68
Количество шагов: 9
Полученная позиция:
_________________
1|_|_|_|_|_|_|*|_|
2|_|*|_|_|_|_|_|_|
3|_|_|_|_|_|*|_|_|
4|_|_|*|_|_|_|_|_|
5|*|_|_|_|_|_|_|_|
6|_|_|_|*|_|_|_|_|
7|_|_|_|_|_|_|_|*|
8|_|_|_|_|*|_|_|_|
_________________


Введите кол-во экземпляров (k): 90
Введите кол-во выбрасываемых случаев (1-(k-2)): 62
Количество шагов: 7
Полученная позиция:
_________________
1|_|_|_|_|_|_|_|*|
2|_|*|_|_|_|_|_|_|
3|_|_|_|*|_|_|_|_|
4|*|_|_|_|_|_|_|_|
5|_|_|_|_|_|_|*|_|
6|_|_|_|_|*|_|_|_|
7|_|_|*|_|_|_|_|_|
8|_|_|_|_|_|*|_|_|
_________________


Введите кол-во экземпляров (k): 60
Введите кол-во выбрасываемых случаев (1-(k-2)): 38
Количество шагов: 13
Полученная позиция:
_________________
1|*|_|_|_|_|_|_|_|
2|_|_|_|_|*|_|_|_|
3|_|_|_|_|_|_|_|*|
4|_|_|_|_|_|*|_|_|
5|_|_|*|_|_|_|_|_|
6|_|_|_|_|_|_|*|_|
7|_|*|_|_|_|_|_|_|
8|_|_|_|*|_|_|_|_|
_________________



Введите кол-во экземпляров (k): 40
Введите кол-во выбрасываемых случаев (1-(k-2)): 22
Количество шагов: 24
Полученная позиция:
_________________
1|_|_|_|*|_|_|_|_|
2|_|_|_|_|_|_|_|*|
3|*|_|_|_|_|_|_|_|
4|_|_|*|_|_|_|_|_|
5|_|_|_|_|_|*|_|_|
6|_|*|_|_|_|_|_|_|
7|_|_|_|_|_|_|*|_|
8|_|_|_|_|*|_|_|_|
_________________

*/