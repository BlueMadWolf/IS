#include "Ugolki.h"
#include <climits>

using namespace std;

//���� �������� ������ �������� 
//����1 https://stackoverrun.com/ru/q/9394120
int minimax(int depth, checkers* cur){
	if (!depth || cur->isEnd())
		return heuristic1(board, cur);
	// ���� ���������
	int best_score;
	if(cur == me){
		best_score = INT_MIN;   //������������ ���������� ���. 
		for(int x = 0; x < cur->position.size(); ++x){
			list<int> variants = cur->variants_of_steps(x);
			for(int y : variants){
				checkers* temp = cur->step(x,y);
				int score = minimax(depth-1, temp); //����� ����������� ���������, � ����������� ������ ����???? 
				best_score = max(score, best_score);
			}
		}
	}
	//���� ���������
	else{
		best_score = INT_MAX;   //������������ ���������� ���. 
		for(int x = 0; x < cur->position.size(); ++x){
			list<int> variants = cur->variants_of_steps(x);
			for(int y : variants){
				checkers* temp = cur->step(x,y);
				int score = minimax(depth-1, temp);  //����� ����������� ���������, � ����������� ���� ����������????
				best_score = min(score, best_score);
			}
		}
	}
	return best_score;
}   