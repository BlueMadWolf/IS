#include <iostream>
#include <vector>
#include <list>
#include <queue>
using namespace std;

struct border
{
	border * parent; //����� ��?
	vector<int> positions;

	border(vector<int> v, border * par = nullptr) : positions(v), parent(par)
	{ 
		good_pos.resize(8, true); 

		if (parent != nullptr)
			mutation();
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

	//��� �������� �������
	vector<bool> good_pos;
public:
	//������� �����������
	int suitability()
	{
		int cnt = 0;

		for (int i = 0; i < 7; ++i)
			for (int j = i + 1; j < 8; ++j)
				if (non_attacking_pair(i, j))
					cnt++;
				else
					good_pos[i] = false;

		return cnt;
	}

	//�������
	void mutation()
	{
		if (rand() % 1)
		{
			positions[rand() % 7] = rand() % 8 + 1;
		}
	}

	void control_mutation()
	{
		if (rand() % 1)
		{
			int pos = rand() % 7;
			while (good_pos[pos])
				pos = rand() % 7;
			positions[pos] = rand() % 8 + 1;
		}
	}

	pair<border *, border *> childs(border * other_parent)
	{
		int del = rand() % 7 + 1;
		vector<int> child_pos1;
		vector<int> child_pos2;

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

		return pair<border*, border *>(new border(child_pos1), new border(child_pos2));
	}

};

//����� �������, ��� ������� �������������
void selection(priority_queue<border * > & q)
{
	q.pop(); //�������� ������ �������
	q.push(q.top());
};

bool is_goal(border * b)
{
	int f = 0;
	for (int i = 1; i < 7; ++i)
		f++;
	return b->suitability() == f;
}

int main()
{
}