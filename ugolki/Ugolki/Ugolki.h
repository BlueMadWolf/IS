#pragma once
#include <iostream>
#include <vector>
#include <string>
#include <list>
#include <set>
#include <algorithm>


using namespace std;

std::vector<bool> board(64, true); //��� �������� ������ �� ���������� �������
checkers * me, *rival;

//��������� ������ �����
struct checkers
{
	checkers * parent;
	std::vector<int> position;
	int num_player;

	checkers(std::string s, int num_player, checkers * par = nullptr):parent(par)
	{
		this->num_player = num_player;
		for (int i = 0; i < 12; ++i)
		{
			position.push_back((s[i * 2] - 'A' + 1) + (s[i * 2 + 1] - '1') * 8);
			board[(s[i * 2] - 'A' + 1) + (s[i * 2 + 1] - '1') * 8] = false; //���������, ��� ������ ������ ������ ������
		}
	}

	checkers(std::vector<int> pos, int numPlayer, checkers * par = nullptr) :parent(par), position(pos), num_player(numPlayer) {}

	//������� �������� ���� � �������� � 1 ���
	checkers * step(int num_check, int new_positions)
	{
		std::vector<int> v = position;

		board[v[num_check]] = true;  //�� �������� �������� board
		board[new_positions] = false;

		v[num_check] = new_positions;
		return new checkers(v, num_player, this);
	}

	//�������� �� ������� ������ 
	bool right_free(int our_pos) 
	{
		if (our_pos % 8 != 7)
			if (board[our_pos + 1])
				return true;
		return false;
	}

	//�������� �� ������� �����
	bool left_free(int our_pos)
	{
		if (our_pos % 8 != 0)
			if (board[our_pos - 1])
				return true;
		return false;
	}

	//�������� �� ������� �����
	bool down_free(int our_pos)
	{
		if (our_pos / 8 != 0)
			if (board[our_pos - 8])
				return true;
		return false;
	}

	//�������� �� ������� ������
	bool up_free(int our_pos)
	{
		if (our_pos / 8 != 7)
			if (board[our_pos + 8])
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

	//�������� �� ������ ����������� ��������
	bool isEnd()
	{
		if (num_player == 1)
		{
			for (int i = 0; i < 12; ++i)
				if (position[i] % 8 < 5 || position[i] / 8 < 5)
					return false;
		}
		else
		{
			for (int i = 0; i < 12; ++i)
				if (position[i] % 8 > 2 || position[i] / 8 > 2)
					return false;
		}

		return true;
	}
};

int manhattan_dist(int curr_pos, int goal_pos)
{
	return abs(goal_pos - curr_pos) / 8 + abs(goal_pos - curr_pos) % 8;
}

vector<pair<int, int>>& get_manh_distances(checkers* curr_player)
{
	//�������, ���� ����������
	vector<pair<int, int>> manh_distances(12);

	int goal_pos = 0;
	if (curr_player->num_player == 1)
		goal_pos = 63;

	for (int i = 0; i < 12; ++i)
	{
		manh_distances[i] = make_pair(curr_player->position[i], manhattan_dist(curr_player->position[i], goal_pos));
	}

	//���������� �� �����������
	sort(manh_distances.begin(), manh_distances.end(),
		[](pair<int, int> p1, pair<int, int> p2) {return p1.second < p2.second; });

	return manh_distances;
}

int closest_to_goal_free_position(vector<bool>& curr_board, int num_player)
{
	vector<int> variants_of_position(28);
	if (num_player == 1)
	{
		variants_of_position = {63, 62, 55, 61, 54, 47, 60, 53, 46, 39, 59, 52, 
			45, 38, 31, 58, 51, 44, 37, 30, 23, 57, 50, 43, 36, 29, 22, 15};
	}
	else
	{
		variants_of_position = { 0, 1, 8, 2, 9, 16, 3, 10, 17, 24, 4, 11, 
			18, 25, 32, 5, 12, 19, 26, 33, 40, 6, 13, 20, 27, 34, 41, 48 };
	}

	for (int i = 0; i < variants_of_position.size(); ++i)
	{
		if (curr_board[variants_of_position[i]])
			return variants_of_position[i];
	}
}

int cnt_steps_to_best_free_pos(vector<bool> curr_board, checkers * curr_player, int curr_pos)
{
	int best_pos = closest_to_goal_free_position(curr_board, curr_player->num_player);
	
}


int heuristic1(vector<bool> curr_board, checkers * curr_player)
{
	vector<bool> old_board = board;
	board = curr_board;

	vector<pair<int, int>> manh_distances = get_manh_distances(curr_player);
	

	board = old_board;
}