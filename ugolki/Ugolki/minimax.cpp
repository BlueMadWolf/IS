#include "Ugolki.h"
#include <climits>

using namespace std;

//Пока минимакс чистый пытаемся 
//Сайт1 https://stackoverrun.com/ru/q/9394120
int minimax(int depth, checkers* cur){
	if (!depth || cur->isEnd())
		return heuristic1(board, cur);
	// Если компьютер
	int best_score;
	if(cur == me){
		best_score = INT_MIN;   //Внимательнее посмотреть тут. 
		for(int x = 0; x < cur->position.size(); ++x){
			list<int> variants = cur->variants_of_steps(x);
			for(int y : variants){
				checkers* temp = cur->step(x,y);
				int score = minimax(depth-1, temp); //Здесь запускается противник, с сохранением нашего хода???? 
				best_score = max(score, best_score);
			}
		}
	}
	//Если противник
	else{
		best_score = INT_MAX;   //Внимательнее посмотреть тут. 
		for(int x = 0; x < cur->position.size(); ++x){
			list<int> variants = cur->variants_of_steps(x);
			for(int y : variants){
				checkers* temp = cur->step(x,y);
				int score = minimax(depth-1, temp);  //Здесь запускается компьютер, с сохранением хода противника????
				best_score = min(score, best_score);
			}
		}
	}
	return best_score;
}   