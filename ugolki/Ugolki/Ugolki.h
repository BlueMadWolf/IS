#pragma once
#include <iostream>
#include <vector>
#include <string>

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

	checkers * step(int num_check, int new_positions)
	{
		std::vector<int> v = position;

		border[v[num_check]] = true;  //не забываем изменить border
		border[new_positions] = false;

		v[num_check] = new_positions;
		return new checkers(v, this);
	}
};