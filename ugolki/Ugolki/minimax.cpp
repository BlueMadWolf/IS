#include "Ugolki.h"
#include <climits>

using namespace std;

int _score(int alpha, int beta){  //depth ���� �� ����������, ������� ���������� ����� �� �����
	checkers x(); //��������. �� ������ �������� ����� ���� �������
	int score_best = alpha;                          
	int score;
	// ���� �� ���� ���������� �������
	//���������� ���������� ���� � ���������� ������ � score
	//����������� ���������� ������� score = -score_alphabeta (depth - 1, beta, -best); //-beta?
	//
	if (score > score_best) {
      score_best = score;
      if (score_best > beta)
		  return score_best;
        //break;    
    }
}

void minimax(){
	checkers start_position(); //������� ��� ��������� ���������� ���� ����������
	int alpha = INT_MIN, beta = INT_MAX;
	//�������������� ������� �����
	//
	//_score(alpha = -INFINITY, beta = +INFINITY);
	//
	//
}