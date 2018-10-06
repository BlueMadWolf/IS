#include "Ugolki.h"
#include <climits>

using namespace std;

int _score(int alpha, int beta){  //depth пока не используем, сначала раскрываем ветки до конца
	checkers x(); //заглушка. Ќа каждой итерации будет дана позици€
	int score_best = alpha;                          
	int score;
	// цикл по всем получаемым сосед€м
	//вычисление следующего хода и сохранение оценки в score
	//рекурисивно вызываетс€ функци€ score = -score_alphabeta (depth - 1, beta, -best); //-beta?
	//
	if (score > score_best) {
      score_best = score;
      if (score_best > beta)
		  return score_best;
        //break;    
    }
}

void minimax(){
	checkers start_position(); //ѕозици€ при получении очередного хода противника
	int alpha = INT_MIN, beta = INT_MAX;
	//»нициализируем игровую доску
	//
	//_score(alpha = -INFINITY, beta = +INFINITY);
	//
	//
}