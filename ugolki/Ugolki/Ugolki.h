#pragma once
#include <iostream>
#include <vector>
#include <string>
#include <list>
#include <set>
#include <algorithm>


using namespace std;

vector<bool> board(64, true); //для проверки занята ли конкретная позиция

//структура набора шашек
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
			board[(s[i * 2] - 'A' + 1) + (s[i * 2 + 1] - '1') * 8] = false; //указываем, что данная клетка теперь занята
		}
	}

	checkers(std::vector<int> pos, int numPlayer, checkers * par = nullptr) :parent(par), position(pos), num_player(numPlayer) {}

	//создает дочерний узел с разницей в 1 шаг
	checkers * step(int num_check, int new_positions)
	{
		std::vector<int> v = position;

		board[v[num_check]] = true;  //не забываем изменить board
		board[new_positions] = false;

		v[num_check] = new_positions;
		return new checkers(v, num_player, this);
	}

	~checkers() 
	{
		delete parent;
		delete &position;
	}

	//свободна ли позиция справа 
	bool right_free(int our_pos) 
	{
		if (our_pos % 8 != 7)
			if (board[our_pos + 1])
				return true;
		return false;
	}

	//свободна ли позиция слева
	bool left_free(int our_pos)
	{
		if (our_pos % 8 != 0)
			if (board[our_pos - 1])
				return true;
		return false;
	}

	//свободна ли позиция снизу
	bool down_free(int our_pos)
	{
		if (our_pos / 8 != 0)
			if (board[our_pos - 8])
				return true;
		return false;
	}

	//свободна ли позиция сверху
	bool up_free(int our_pos)
	{
		if (our_pos / 8 != 7)
			if (board[our_pos + 8])
				return true;
		return false;
	}

private:

	//внутренняя функция для variants_of_positions, проверяет возможность прыжков
	void new_variants_of_steps(int our_pos, std::set<int> & steps, std::list<int> & new_steps)
	{

		if (our_pos % 8 != 7 && !right_free(our_pos)) //проверяем прыжок вправо
		{
			int new_pos = our_pos + 1;
			if (right_free(new_pos) && steps.find(new_pos + 1) == steps.end())
			{
				new_steps.push_back(new_pos + 1);
				new_pos += 1;
				new_variants_of_steps(new_pos, steps, new_steps);
			}
		}

		if (our_pos % 8 != 0 && !left_free(our_pos)) //проверяем прыжок влево
		{
			int new_pos = our_pos -  1;
			if (left_free(new_pos) && steps.find(new_pos - 1) == steps.end())
			{
				new_steps.push_back(new_pos - 1);
				new_pos -= 1;
				new_variants_of_steps(new_pos, steps, new_steps);
			}
		}

		if (our_pos / 8 != 7 && !up_free(our_pos)) //проверяем прыжок вверх
		{
			int new_pos = our_pos + 8;
			if (up_free(new_pos) && steps.find(new_pos + 8) == steps.end())
			{
				new_steps.push_back(new_pos + 8);
				new_pos += 8;
				new_variants_of_steps(new_pos, steps, new_steps);
			}
		}

		if (our_pos / 8 != 0 && !down_free(our_pos)) //проверяем прыжок вниз
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

	//выдает список всех позиций, которые можно получить за 1 ход из текущей
	std::list<int> variants_of_steps(int our_pos)
	{
		std::list<int> new_steps;
		std::set<int> steps;

		steps.insert(our_pos); // запоминаем позицию, чтобы не зациклиться

		if (right_free(our_pos)) //проверяем, свободна ли позиция справа
		{
			new_steps.push_back(our_pos + 1); //если да, то делаем шаг вправо
			steps.insert(our_pos + 1); // запоминаем позицию, чтобы не зациклиться
		}
		else
			if (our_pos % 8 != 7) //если позиция занята
			{
				int new_pos = our_pos + 1;
				if (right_free(new_pos) && steps.find(our_pos + 1) == steps.end()) //если после правой свободно, то перепрыгиваем и смотрим
				{																  //можно ли сделать еще прыжки
					new_steps.push_back(new_pos + 1);
					new_pos += 1;
					new_variants_of_steps(new_pos, steps, new_steps);
				}
			}

		if (left_free(our_pos)) //проверяем также для левой стороны
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

		if (up_free(our_pos)) //проверяем верх
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

		if (down_free(our_pos)) //проверяем низ
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

	//является ли данная расстановка конечной
	bool isEnd()
	{
		if (num_player == 1)
		{
			for (int i = 0; i < 12; ++i)
				if (position[i] % 8 < 4 || position[i] / 8 < 5)
					return false;
		}
		else
		{
			for (int i = 0; i < 12; ++i)
				if (position[i] % 8 > 3 || position[i] / 8 > 2)
					return false;
		}

		return true;
	}
};

checkers * me, *rival;

int manhattan_dist(int curr_pos, int goal_pos)
{
	return abs(goal_pos - curr_pos) / 8 + abs(goal_pos - curr_pos) % 8;
}

vector<pair<int, int>>& get_manh_distances(checkers* curr_player)
{
	//Позиция, манх расстояние
	vector<pair<int, int>> manh_distances(12);

	int goal_pos = 0;
	if (curr_player->num_player == 1)
		goal_pos = 63;

	for (int i = 0; i < 12; ++i)
	{
		manh_distances[i] = make_pair(curr_player->position[i], manhattan_dist(curr_player->position[i], goal_pos));
	}

	//Сортировка по расстояниям
	sort(manh_distances.begin(), manh_distances.end(),
		[](pair<int, int> p1, pair<int, int> p2) {return p1.second < p2.second; });

	return manh_distances;
}

vector<pair<int, int>>& get_manh_distances(list<int>& variants, int goal_pos)
{
	//Позиция, манх расстояние
	vector<pair<int, int>> manh_distances(variants.size());

	int i = 0;
	for (int curr_var_pos: variants)
	{
		manh_distances[i] = make_pair(curr_var_pos, manhattan_dist(curr_var_pos, goal_pos));
		++i;
	}

	//Сортировка по расстояниям
	sort(manh_distances.begin(), manh_distances.end(),
		[](pair<int, int> p1, pair<int, int> p2) {return p1.second < p2.second; });

	return manh_distances;
}

int closest_to_goal_free_position(vector<bool>& curr_board, int num_player)
{
	vector<int> variants_of_best_position(28);
	if (num_player == 1)
	{
		variants_of_best_position = {63, 62, 55, 61, 54, 47, 60, 53, 46, 52, 45, 44,
			39, 59, 38, 51, 37, 43, 36, 35, 31, 58, 30, 50, 29, 42, 28, 34, 27, 26};
	}
	else
	{
		variants_of_best_position = { 0, 1, 8, 2, 9, 16, 3, 10, 17, 11, 18, 19,
			24, 4, 25, 12, 26, 20, 27, 28, 32, 5, 33, 13, 34, 21, 35, 29, 36, 37};
	}

	for (int i = 0; i < variants_of_best_position.size(); ++i)
	{
		if (curr_board[variants_of_best_position[i]])
			return variants_of_best_position[i];
	}
	return 0;
}

int cnt_steps_to_best_free_pos(vector<bool>& curr_board, checkers * curr_player, int curr_pos)
{
	
	int best_pos = closest_to_goal_free_position(curr_board, curr_player->num_player);
	
	if (curr_pos == best_pos)
		return 0;

	list<int> vars = curr_player->variants_of_steps(curr_pos);
	if (vars.size() == 0)
	{
		return 16;
	}

	
	set<vector<int>> used_positions(vector<int>());

	int cnt_steps = 0;
	while (true)
	{
		int min_manh = 16;
		int min_step = 0;
		vector<pair<int, int>> manh_distances = get_manh_distances(curr_player);
		for (int next_pos : vars)
		{
			int next_dist = manhattan_dist(next_pos, best_pos);
			if (next_dist < min_manh)
			{
				min_manh = next_dist;
				min_step = next_pos;
			}
		}
	}
}


int heuristic1(vector<bool> curr_board, checkers * curr_player)
{
	vector<bool> old_board = board;
	board = curr_board;
	checkers * old_player = new checkers(curr_player->position, curr_player->num_player, curr_player->parent);

	vector<pair<int, int>> manh_distances = get_manh_distances(curr_player);
	

	board = old_board;
	delete curr_player;
	curr_player = old_player;
	return 0;
}