//#include "Ugolki.h"
#include "Ugolki.h"

void InputData()
{
	std::cout << "Will you be player 1 or 2?";
	int num_p;
	std::cin >> num_p;

	if (num_p == 1)
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

int main()
{
	InputData();
	start(me, rival);
}