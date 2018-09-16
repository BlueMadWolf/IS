#include <iostream>
#include <vector>
#include <string>
#include <numeric>

using namespace std;

vector<int> positions(16);

void inputData()
{
	string initial_position;
	cin >> initial_position;

	for (int i = 0; i < 16; ++i)
		if (isdigit(initial_position[i]))
			positions[i] = initial_position[i] - '0';
		else
			if ('A' <= initial_position[i] && initial_position[i] <= 'F')
				positions[i] = initial_position[i] - 'A' + 10;
			else
				throw "Неверные входные данные";
}

//проверка существования решения
bool verificationExSolution()
{
	int e; //номер ряда пустой клетки от 1
	vector<int> ni (15, 0); //кол-во меньшеих квадратиков, расположенных после iго

	for (int i = 15; i >= 0; --i)
		if (positions[i] == 0)
			e = i / 4 + 1;
		else
		{
			for (int j = 15; j > i; --j)
				if (positions[j] < positions[i])
					ni[positions[i] - 1]++;
		}

	return (accumulate(ni.begin(), ni.end(), 0) + e) % 2 == 0;
}

int main()
{
	inputData();

	if (!verificationExSolution())
		cout << "It is impossible to find a solution." << endl;
	else
	{
	}
}