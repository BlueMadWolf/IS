#pragma once
#include <iostream>
#include <vector>
#include <string>
#include <list>
#include <set>

std::vector<bool> border(64, true); //��� �������� ������ �� ���������� �������
checkers * me, *rival;

//��������� ������ �����
struct checkers
{
	checkers * parent;
	std::vector<int> position;

	checkers(std::string s, checkers * par = nullptr):parent(par)
	{
		for (int i = 0; i < 12; ++i)
		{
			position.push_back((s[i * 2] - 'A' + 1) + (s[i * 2 + 1] - '0') * 8);
			border[(s[i * 2] - 'A' + 1) + (s[i * 2 + 1] - '0') * 8] = false; //���������, ��� ������ ������ ������ ������
		}
	}

	checkers(std::vector<int> pos, checkers * par = nullptr) :parent(par), position(pos) {}

	//������� �������� ���� � �������� � 1 ���
	checkers * step(int num_check, int new_positions)
	{
		std::vector<int> v = position;

		border[v[num_check]] = true;  //�� �������� �������� border
		border[new_positions] = false;

		v[num_check] = new_positions;
		return new checkers(v, this);
	}

	//�������� �� ������� ������ 
	bool right_free(int our_pos) 
	{
		if (our_pos % 8 != 7)
			if (border[our_pos + 1])
				return true;
		return false;
	}

	//�������� �� ������� �����
	bool left_free(int our_pos)
	{
		if (our_pos % 8 != 0)
			if (border[our_pos - 1])
				return true;
		return false;
	}

	//�������� �� ������� �����
	bool down_free(int our_pos)
	{
		if (our_pos / 8 != 0)
			if (border[our_pos - 8])
				return true;
		return false;
	}

	//�������� �� ������� ������
	bool up_free(int our_pos)
	{
		if (our_pos / 8 != 7)
			if (border[our_pos + 8])
				return true;
		return false;
	}

private:

	//���������� ������� ��� variants_of_positions, ��������� ����������� �������
	void new_variants_of_steps(int our_pos, std::set<int> & steps, std::list<int> & new_steps)
	{

		if (our_pos % 8 != 7 && !right_free(our_pos)) //��������� ������ ������
		{
			int new_pos = our_pos + 1;
			if (right_free(new_pos) && steps.find(new_pos + 1) == steps.end())
			{
				new_steps.push_back(new_pos + 1);
				new_pos += 1;
				new_variants_of_steps(new_pos, steps, new_steps);
			}
		}

		if (our_pos % 8 != 0 && !left_free(our_pos)) //��������� ������ �����
		{
			int new_pos = our_pos -  1;
			if (left_free(new_pos) && steps.find(new_pos - 1) == steps.end())
			{
				new_steps.push_back(new_pos - 1);
				new_pos -= 1;
				new_variants_of_steps(new_pos, steps, new_steps);
			}
		}

		if (our_pos / 8 != 7 && !up_free(our_pos)) //��������� ������ �����
		{
			int new_pos = our_pos + 8;
			if (up_free(new_pos) && steps.find(new_pos + 8) == steps.end())
			{
				new_steps.push_back(new_pos + 8);
				new_pos += 8;
				new_variants_of_steps(new_pos, steps, new_steps);
			}
		}

		if (our_pos / 8 != 0 && !down_free(our_pos)) //��������� ������ ����
		{
			int new_pos = our_pos - 8;
			if (down_free(new_pos) && steps.find(new_pos - 8) == steps.end())
			{
				new_steps.push_back(new_pos - 8);
				new_pos -= 8;
				new_variants_of_steps(new_pos, steps, new_steps);
			}
		}
	}

public:

	//������ ������ ���� �������, ������� ����� �������� �� 1 ��� �� �������
	std::list<int> variants_of_steps(int our_pos)
	{
		std::list<int> new_steps;
		std::set<int> steps;

		steps.insert(our_pos); // ���������� �������, ����� �� �����������

		if (right_free(our_pos)) //���������, �������� �� ������� ������
		{
			new_steps.push_back(our_pos + 1); //���� ��, �� ������ ��� ������
			steps.insert(our_pos + 1); // ���������� �������, ����� �� �����������
		}
		else
			if (our_pos % 8 != 7) //���� ������� ������
			{
				int new_pos = our_pos + 1;
				if (right_free(new_pos) && steps.find(our_pos + 1) == steps.end()) //���� ����� ������ ��������, �� ������������� � �������
				{																  //����� �� ������� ��� ������
					new_steps.push_back(new_pos + 1);
					new_pos += 1;
					new_variants_of_steps(new_pos, steps, new_steps);
				}
			}

		if (left_free(our_pos)) //��������� ����� ��� ����� �������
		{
			new_steps.push_back(our_pos - 1);
			steps.insert(our_pos - 1);
		}
		else
			if (our_pos % 8 != 0)
			{
				int new_pos = our_pos - 1;
				if (left_free(new_pos) && steps.find(our_pos - 1) == steps.end())
				{
					new_steps.push_back(new_pos - 1);
					new_pos -= 1;
					new_variants_of_steps(new_pos, steps, new_steps);
				}
			}

		if (up_free(our_pos)) //��������� ����
		{
			new_steps.push_back(our_pos + 8);
			steps.insert(our_pos + 8);
		}
		else
			if (our_pos / 8 != 7)
			{
				int new_pos = our_pos + 8;
				if (up_free(new_pos) && steps.find(our_pos + 8) == steps.end())
				{
					new_steps.push_back(new_pos + 8);
					new_pos += 8;
					new_variants_of_steps(new_pos, steps, new_steps);
				}
			}

		if (down_free(our_pos)) //��������� ���
		{
			new_steps.push_back(our_pos - 8);
			steps.insert(our_pos - 8);
		}
		else
			if (our_pos / 8 != 0)
			{
				int new_pos = our_pos - 8;
				if (down_free(new_pos) && steps.find(our_pos - 8) == steps.end())
				{
					new_steps.push_back(new_pos - 8);
					new_pos -= 8;
					new_variants_of_steps(new_pos, steps, new_steps);
				}
			}
		return new_steps;
	}
};