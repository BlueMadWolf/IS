#include "Ugolki.h"

checkers * me, * rival;

void InputData()
{
	std::cout << "Will you be player 1 or 2?";
	int num;
	std::cin >> num;

	if (num == 1)
	{
		me = new checkers("A8B8C8D8A7B7C7D7A6B6C6D6");
		rival = new checkers("H1G1F1E1H2G2F2E2H3G3F3E3");
	}
	else
	{
		{
			rival = new checkers("A8B8C8D8A7B7C7D7A6B6C6D6");
			me = new checkers("H1G1F1E1H2G2F2E2H3G3F3E3");
		}
	}

}

int main()
{
	InputData();
}