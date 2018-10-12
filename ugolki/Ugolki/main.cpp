#include "Ugolki.h"

std::vector<string> print_info(11);

void based_template()
{
	print_info[0] = "  A B C D E F G H ";
	print_info[1] = "-------------------";
	print_info[10] = print_info[1];

	for (int i = 0; i < 8; ++i)
		print_info[i + 2] = to_string(i + 1) + "|_|_|_|_|_|_|_|_|";
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
	bool end = false;

	print_board();

	if (rival->num_player == 1)
	{
		cout << endl << "Choose cheker (1-12 (a = 10, c = 12)): ";
		char c;
		cin >> c;
		cout << endl << "Make step: ";
		string s;
		cin >> s;
		rival_step(c, s);
		print_board();
		end = rival->isEnd();
		s = true;
	}

	while (!end)
	{
		
		std::pair<int, int> st = start(me, rival);
	    me = me->step(st.first, st.second);
		print_board();
		end = me->isEnd();
		if (end)
		{
			cout << "Player" + to_string(rival->num_player) + " lose" << endl;
			s = false;
			break;
		}
		else
		{
			cout << endl << "Choose cheker (1-12 (a = 10, c = 12)): ";
			char c;
			cin >> c;
			cout << endl << "Make step: ";
			string s;
			cin >> s;
			rival_step(c, s);
			print_board();
			end = rival->isEnd();
			s = true;
		}
	}

	if (s)
		cout << "Player" + to_string(me->num_player) + " lose" << endl;
}