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

void find_pos()
{
	int m = 2;
	for (int i = 0; i < 8; ++i)
	{
		print_info[2 + (me->position[i]) % 8][(2 + (me->position[i]) / 8) * 2] = '0';
		print_info[2 + (rival->position[i]) % 8][(2 + (rival->position[i]) / 8) * 2] = (char)('0' + i);
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

void rival_step(int n, string s)
{
	int n_p = (s[0] - 'A') * 8 + s[1] - '1';
	rival->step(n, n_p);
}

int main()
{
	based_template();
	InputData();
	bool end = false;

	while (!end)
	{
		print_board();
		std::pair<int, int> st = start(me, rival);
	    me->step(st.first, st.second);
		print_board();
		end = me->isEnd();
		if (end)
			cout<< "Player" + to_string(rival->num_player) + " lose" << endl;
		else
		{
			cout << endl << "Choose cheker (1-8): " ;
			int n;
			cin >> n;
			cout << endl << "Make step: ";
			string s;
			cin >> s;
			rival_step(n, s);
			print_board();
			end = rival->isEnd();
			system("Pause");
		}
	}

}