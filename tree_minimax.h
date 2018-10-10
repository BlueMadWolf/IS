#include "Ugolki.h"

class board_node{
public:
	board_node* parent;
	vector<bool> position;
	int ind, pos;
	int score;
	board_node():parent(nullptr), ind (0), pos (0){position.assign(board.begin(),board.end());}

	board_node(checkers * curr, int i, int ps, board_node* p): parent(p), ind (i), pos (ps){
		position = p->position;
		step(position, curr, ind, pos);
	}
};

void step(vector<bool> & cur_board, checkers* cur, int num_check, int new_positions){
	cur_board[cur->position[num_check]] = true;  
	cur_board[new_positions] = false;
	cur->position[num_check] = new_positions;
}

struct bd_comp{
	bool operator() (board_node* s1, board_node* s2) const{
		return (s1->score < s2->score); //??
	}
};