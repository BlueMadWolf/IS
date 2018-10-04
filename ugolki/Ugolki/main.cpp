#include "Ugolki.h"

void InputData()
{
	std::cout << "Will you be player 1 or 2?";
	std::cin >> num;

	if (num == 1)
	{
		me = new checkers("A1B1C1D1A2B2C2D2A3B3C3D3");
		rival = new checkers("H8G8F8E8H7G7F7E7H6G6F6E6");
	}
	else
	{
		{
			rival = new checkers("A1B1C1D1A2B2C2D2A3B3C3D3");
			me = new checkers("H8G8F8E8H7G7F7E7H6G6F6E6");
		}
	}
}

int main()
{
	InputData();
}