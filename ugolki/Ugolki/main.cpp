#include "Ugolki.h"

std::vector<string> print_info(11);
std::vector<int> home1(12);
std::vector<int> home2(12);

void based_template()
{
	print_info[0] = "  A B C D E F G H ";
	print_info[1] = "-------------------";
	print_info[10] = print_info[1];

	for (int i = 0; i < 8; ++i)
		print_info[i + 2] = to_string(i + 1) + "|_|_|_|_|_|_|_|_|";

	for (int i = 0; i < 4; ++i)
	{
		home1[i] = i;
		home1[i + 4] = i + 8;
		home1[i + 8] = i + 16;

		home2[i] = 63 - i;
		home2[i + 4] = 63 - (i + 8);
		home2[i + 8] = 63 - (i + 16);
	}
}

void delete_info()
{
	for (int i = 0; i < 8; ++i)
		print_info[i + 2] = to_string(i + 1) + "|_|_|_|_|_|_|_|_|";
}

void find_pos()
{
	int m = 2;
	delete_info();
	for (int i = 0; i < 12; ++i)
	{
		print_info[2 + (me->position[i]) / 8][(1 + (me->position[i]) % 8) * 2] = '0';
		if(i > 8)
			print_info[2 + (rival->position[i]) / 8][(1 + (rival->position[i]) % 8) * 2] = (char)('a' + i-9);
		else
			print_info[2 + (rival->position[i]) / 8][(1 + (rival->position[i]) % 8) * 2] = (char)('1' + i);
	}
}

void print_board()
{
	find_pos();
	for (int i = 0; i < 11; ++i)
		cout << print_info[i] << endl;
}

void InputData()
{
	std::cout << "Will you be player 1 or 2? :  ";
	int num_p;
	std::cin >> num_p;

	if (num_p == 2)
	{
		me = new checkers("A1B1C1D1A2B2C2D2A3B3C3D3", 1);
		rival = new checkers("H8G8F8E8H7G7F7E7H6G6F6E6", 2);
	}
	else
	{
		{
			rival = new checkers("A1B1C1D1A2B2C2D2A3B3C3D3", 1);
			me = new checkers("H8G8F8E8H7G7F7E7H6G6F6E6", 2);
		}
	}
}

bool inhome(checkers * c1)
{
	if (c1->num_player == 1)
	{
		for (int i = 0; i < 12; ++i)
			if (find(home1.begin(), home1.end(), c1->position[i]) != home1.end())
				return true;
	}
	else
		for (int i = 0; i < 12; ++i)
			if (find(home2.begin(), home2.end(), c1->position[i]) != home2.end())
				return true;

	return false;
}

void rival_step(char c, string s)
{
	int n = 0;
	if (isdigit(c))
		n = c - '1';
	else
		n = c - 'a' + 9;
	int n_p = (s[0] - 'A') + (s[1] - '1')*8;
	rival = rival->step(n, n_p);
}

bool s;

int main()
{
	based_template();
	InputData();
	bool end = false, fl = false;
	int step = 0;

	print_board();

	if (rival->num_player == 1)
	{
		step++;
		cout << endl << "Step: " << step << endl << "Choose cheker (1-12 (a = 10, c = 12)): ";
		char c;
		cin >> c;
		cout << endl << "Make step: ";
		string s;
		cin >> s;
		rival_step(c, s);
		print_board();
		end = rival->isEnd();
		fl = true;
	}

	while (!end)
	{
		newstart();
		//std::pair<int, int> st = find_step(board,next_move->curr_board);
		//std::pair<int, int> st = start(me, rival);
		//me = me->step(find_index(me->position, st.first), st.second);
		step++;
		me = me->step(answer.first, answer.second);
		cout << "Step: " << step << endl;
		print_board();
		end = me->isEnd();
		if (step > 39 && inhome(me))
		{
			fl = true;
			break;
		}

		if (end)
		{
			cout << "Player" + to_string(rival->num_player) + " lose" << endl;
			fl = false;
			break;
		}
		else
		{
			step++;
			cout << endl << "Step: " << step << endl << "Choose cheker (1-12 (a = 10, c = 12)): ";
			char c;
			cin >> c;
			cout << endl << "Make step: ";
			string s;
			cin >> s;
			rival_step(c, s);

			print_board();
			end = rival->isEnd();
			fl = true;

			if (step > 39 && inhome(rival))
			{
				fl = false;
				break;
			}
		}
	}

	if (fl)
		cout << "Player" + to_string(me->num_player) + " lose" << endl;
	else
		cout << "Player" + to_string(rival->num_player) + " lose" << endl;

	system("Pause");
}