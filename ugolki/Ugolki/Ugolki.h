#pragma once
#include <iostream>
#include <vector>
#include <string>
#include <list>
#include <set>

std::vector<bool> border(64, true); //для проверки занята ли конкретная позиция
checkers * me, *rival;

//структура набора шашек
struct checkers
{
	checkers * parent;
	std::vector<int> position;

	checkers(std::string s, checkers * par = nullptr):parent(par)
	{
		for (int i = 0; i < 12; ++i)
		{
			position.push_back((s[i * 2] - 'A' + 1) + (s[i * 2 + 1] - '0') * 8);
			border[(s[i * 2] - 'A' + 1) + (s[i * 2 + 1] - '0') * 8] = false; //указываем, что данная клетка теперь занята
		}
	}

	checkers(std::vector<int> pos, checkers * par = nullptr) :parent(par), position(pos) {}

	//создает дочерний узел с разницей в 1 шаг
	checkers * step(int num_check, int new_positions)
	{
		std::vector<int> v = position;

		border[v[num_check]] = true;  //не забываем изменить border
		border[new_positions] = false;

		v[num_check] = new_positions;
		return new checkers(v, this);
	}

	//свободна ли позиция справа 
	bool right_free(int our_pos) 
	{
		if (our_pos % 8 != 7)
			if (border[our_pos + 1])
				return true;
		return false;
	}

	//свободна ли позиция слева
	bool left_free(int our_pos)
	{
		if (our_pos % 8 != 0)
			if (border[our_pos - 1])
				return true;
		return false;
	}

	//свободна ли позиция снизу
	bool down_free(int our_pos)
	{
		if (our_pos / 8 != 0)
			if (border[our_pos - 8])
				return true;
		return false;
	}

	//свободна ли позиция сверху
	bool up_free(int our_pos)
	{
		if (our_pos / 8 != 7)
			if (border[our_pos + 8])
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
};