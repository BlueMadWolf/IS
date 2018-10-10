#include <climits>
#include "Ugolki.h"
#include <queue>
using namespace std;

const int ddepth = 3;

//priority_queue<board_node*,bd_comp> q; 

int minimax(int depth, bool comp, board_node* bd, int a, int b, checkers* me_c, checkers* rival_c);

pair<int,int> start(checkers* m, checkers* r){
	//Допустим, что берем значения уже готовые
	board_node* s = new board_node();
	checkers* me_c = new checkers(*m);
	checkers* rival_c = new checkers(*r);
	int score_gen = minimax(ddepth, true, s, INT_MIN, INT_MAX, me_c, rival_c);
	//board_node* temp = q.top();
	
	//pair<int,int> pr(temp->ind, temp->pos);
	pair<int, int> pr(1, 1);
	return pr;
}

int minimax(int depth, bool comp, board_node* bd, int a, int b, checkers* me_c, checkers* rival_c){
	if (comp){
		if (!depth || me_c->isEnd()){ 
			int h = heuristic1(bd->position, me_c);
			bd->score = h;
			return h;
		}
	// Если компьютер
		int score = INT_MIN;
		for(int x = 0; x < me_c->position.size(); ++x){
			list<int> variants = me_c->variants_of_steps(x);
			for(int y : variants){
				board_node* next = new board_node(me_c,x,y,bd);
				//if(depth == ddepth) q.push(next);
				score = minimax(depth-1, false, next, a, b, me_c, rival_c); 
				if(next->parent!=nullptr) next->parent->score = score;
				a = max(a, score);
				if (a>=b) return score;	
			}
		}
	}
	//Если противник
	else{
		if (!depth || rival_c->isEnd()){ 
			int h = heuristic1(bd->position, rival_c);
			bd->score = h;
			return h;
		}
		int score = INT_MAX; 
		for(int x = 0; x < rival_c->position.size(); ++x){
			list<int> variants = rival_c->variants_of_steps(x);
			for(int y : variants){
				board_node* next = new board_node(rival_c,x,y,bd);
				//if(depth == ddepth) q.push(next);
				score = minimax(depth-1, true, next, a,b,me_c, rival_c);
				b = min(b, score);
				if (a>=b) return score;
			}
		}
	}
}

void step(vector<bool> & cur_board, checkers* cur, int num_check, int new_positions) {
	cur_board[cur->position[num_check]] = true;
	cur_board[new_positions] = false;
	cur->position[num_check] = new_positions;
}