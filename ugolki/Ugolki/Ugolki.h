#pragma once
#include <iostream>
#include <vector>
#include <string>
#include <list>
#include <set>
#include <algorithm>


using namespace std;

vector<bool> board(64, false); //��� �������� ������ �� ���������� �������

//��������� ������ �����
struct checkers
{
	checkers * parent;
	std::vector<int> position;
	int num_player;

	checkers(std::string s, int num_player, checkers * par = nullptr):parent(par)
	{
		this->num_player = num_player;
		for (int i = 0; i < 12; ++i)
		{
			position.push_back((s[i * 2] - 'A') + (s[i * 2 + 1] - '1') * 8);
			board[(s[i * 2] - 'A') + (s[i * 2 + 1] - '1') * 8] = true; //���������, ��� ������ ������ ������ ������
		}
	}

	checkers(std::vector<int> pos, int numPlayer, checkers * par = nullptr) :parent(par), position(pos), num_player(numPlayer) {}

	//������� �������� ���� � �������� � 1 ���
	checkers * step(int num_check, int new_positions)
	{
		std::vector<int> v = position;

		board[v[num_check]] = false;  //�� �������� �������� board
		board[new_positions] = true;

		v[num_check] = new_positions;
		return new checkers(v, num_player, this);
	}

	//�������� �� ������� ������ 
	bool right_free(int our_pos) 
	{
		if (our_pos % 8 != 7)
			if (!board[our_pos + 1])
				return true;
		return false;
	}

	//�������� �� ������� �����
	bool left_free(int our_pos)
	{
		if (our_pos % 8 != 0)
			if (!board[our_pos - 1])
				return true;
		return false;
	}

	//�������� �� ������� �����
	bool down_free(int our_pos)
	{
		if (our_pos / 8 != 0)
			if (!board[our_pos - 8])
				return true;
		return false;
	}

	//�������� �� ������� ������
	bool up_free(int our_pos)
	{
		if (our_pos / 8 != 7)
			if (!board[our_pos + 8])
				return true;
		return false;
	}

private:

	//���������� ������� ��� variants_of_positions, ��������� ����������� �������
	void new_variants_of_steps(int our_pos, std::set<int> & steps, std::list<int> & new_steps)
	{

		if (our_pos % 8 != 7 && !right_free(our_pos)) //��������� ������ ������
		{
			int new_pos = our_pos + 1;
			if (right_free(new_pos) && steps.find(new_pos + 1) == steps.end())
			{
				new_steps.push_back(new_pos + 1);
				new_pos += 1;
				new_variants_of_steps(new_pos, steps, new_steps);
			}
		}

		if (our_pos % 8 != 0 && !left_free(our_pos)) //��������� ������ �����
		{
			int new_pos = our_pos -  1;
			if (left_free(new_pos) && steps.find(new_pos - 1) == steps.end())
			{
				new_steps.push_back(new_pos - 1);
				new_pos -= 1;
				new_variants_of_steps(new_pos, steps, new_steps);
			}
		}

		if (our_pos / 8 != 7 && !up_free(our_pos)) //��������� ������ �����
		{
			int new_pos = our_pos + 8;
			if (up_free(new_pos) && steps.find(new_pos + 8) == steps.end())
			{
				new_steps.push_back(new_pos + 8);
				new_pos += 8;
				new_variants_of_steps(new_pos, steps, new_steps);
			}
		}

		if (our_pos / 8 != 0 && !down_free(our_pos)) //��������� ������ ����
		{
			int new_pos = our_pos - 8;
			if (down_free(new_pos) && steps.find(new_pos - 8) == steps.end())
			{
				new_steps.push_back(new_pos - 8);
				new_pos -= 8;
				new_variants_of_steps(new_pos, steps, new_steps);
			}
		}
	}

public:

	//������ ������ ���� �������, ������� ����� �������� �� 1 ��� �� �������
	std::list<int> variants_of_steps(int our_pos)
	{
		std::list<int> new_steps;
		std::set<int> steps;

		steps.insert(our_pos); // ���������� �������, ����� �� �����������

		if (right_free(our_pos)) //���������, �������� �� ������� ������
		{
			new_steps.push_back(our_pos + 1); //���� ��, �� ������ ��� ������
			steps.insert(our_pos + 1); // ���������� �������, ����� �� �����������
		}
		else
			if (our_pos % 8 != 7) //���� ������� ������
			{
				int new_pos = our_pos + 1;
				if (right_free(new_pos) && steps.find(our_pos + 1) == steps.end()) //���� ����� ������ ��������, �� ������������� � �������
				{																  //����� �� ������� ��� ������
					new_steps.push_back(new_pos + 1);
					new_pos += 1;
					new_variants_of_steps(new_pos, steps, new_steps);
				}
			}

		if (left_free(our_pos)) //��������� ����� ��� ����� �������
		{
			new_steps.push_back(our_pos - 1);
			steps.insert(our_pos - 1);
		}
		else
			if (our_pos % 8 != 0)
			{
				int new_pos = our_pos - 1;
				if (left_free(new_pos) && steps.find(our_pos - 1) == steps.end())
				{
					new_steps.push_back(new_pos - 1);
					new_pos -= 1;
					new_variants_of_steps(new_pos, steps, new_steps);
				}
			}

		if (up_free(our_pos)) //��������� ����
		{
			new_steps.push_back(our_pos + 8);
			steps.insert(our_pos + 8);
		}
		else
			if (our_pos / 8 != 7)
			{
				int new_pos = our_pos + 8;
				if (up_free(new_pos) && steps.find(our_pos + 8) == steps.end())
				{
					new_steps.push_back(new_pos + 8);
					new_pos += 8;
					new_variants_of_steps(new_pos, steps, new_steps);
				}
			}

		if (down_free(our_pos)) //��������� ���
		{
			new_steps.push_back(our_pos - 8);
			steps.insert(our_pos - 8);
		}
		else
			if (our_pos / 8 != 0)
			{
				int new_pos = our_pos - 8;
				if (down_free(new_pos) && steps.find(our_pos - 8) == steps.end())
				{
					new_steps.push_back(new_pos - 8);
					new_pos -= 8;
					new_variants_of_steps(new_pos, steps, new_steps);
				}
			}
		return new_steps;
	}

	//�������� �� ������ ����������� ��������
	bool isEnd()
	{
		if (num_player == 1)
		{
			for (int i = 0; i < 12; ++i)
				if (position[i] % 8 < 4 || position[i] / 8 < 5)
					return false;
		}
		else
		{
			for (int i = 0; i < 12; ++i)
				if (position[i] % 8 > 3 || position[i] / 8 > 2)
					return false;
		}

		return true;
	}

	friend bool operator==(checkers c1, checkers c2)
	{
		return c1.position == c2.position && c1.parent == c2.parent;
	}
};

checkers * me, *rival;

int manhattan_dist(int curr_pos, int goal_pos)
{
	return abs(goal_pos - curr_pos) / 8 + abs(goal_pos - curr_pos) % 8;
}

//<�������, ������������� ���������e �� goal_pos>
vector<pair<int, int>> get_manh_distances(list<int>& variants, int goal_pos)
{
	//�������, ���� ����������
	vector<pair<int, int>> manh_distances(variants.size());

	int i = 0;
	for (int curr_var_pos: variants)
	{
		manh_distances[i] = make_pair(curr_var_pos, manhattan_dist(curr_var_pos, goal_pos));
		++i;
	}

	//���������� �� �����������
	sort(manh_distances.begin(), manh_distances.end(),
		[](pair<int, int> p1, pair<int, int> p2) {return p1.second < p2.second; });

	return manh_distances;
}


/*
56	57	58	59	60	61	62	63
48	49	50	51	52	53	54	55
40	41	42	43	44	45	46	47
32	33	34	35	36	37	38	39
24	25	26	27	28	29	30	31
16	17	18	19	20	21	22	23
8	9	10	11	12	13	14	15
0	1	2	3	4	5	6	7
*/
//��������� �������, ������� ����� ����� � �������� ��������������
int closest_to_goal_free_position(vector<bool>& curr_board, int num_player)
{
	vector<int> variants_of_best_position(28);
	if (num_player == 1)
	{
		//������ �������� ��������������
		variants_of_best_position = {63, 62, 55, 61, 54, 47, 60, 53, 46, 52, 45, 44,
			//��������� � �������� ��������������
			39, 59, 38, 51, 37, 43, 36, 35, 31, 58, 30, 50, 29, 42, 28, 34, 27, 26};
	}
	else
	{
		//������ �������� ��������������
		variants_of_best_position = { 0, 1, 8, 2, 9, 16, 3, 10, 17, 11, 18, 19,
			//��������� � �������� ��������������
			24, 4, 25, 12, 26, 20, 27, 28, 32, 5, 33, 13, 34, 21, 35, 29, 36, 37};
	}

	for (int i = 0; i < variants_of_best_position.size(); ++i)
	{
		if (!curr_board[variants_of_best_position[i]])
			return variants_of_best_position[i];
	}
	return 0;
}

//���������� ����� �� ������� ������� �� ���������, ��������� � �������������� 
int cnt_steps_to_best_free_pos(vector<bool>& curr_board, checkers * curr_player, int curr_pos)
{
	int best_pos = closest_to_goal_free_position(curr_board, curr_player->num_player);
	
	if (curr_pos == best_pos)
		return 0;

	list<int> vars = curr_player->variants_of_steps(curr_pos);
	if (vars.size() == 0)
	{
		return 16;
	}

	//�������, ������� ��� ��������������
	set<int> used_positions;
	used_positions.insert(curr_pos);

	int cnt_steps = 0;
	while (true)
	{
		if (curr_pos == best_pos)
			return cnt_steps;

		//����� ������� ���� ��� ������� �������
		vars = curr_player->variants_of_steps(curr_pos);
		vector<pair<int, int>> manh_distances = get_manh_distances(vars, best_pos);
		//������ ���������������� ������� � ������ ��������� �����. ������ ������������ �� ���� ����������
		int best_step = -1;
		for (auto& p : manh_distances)
		{
			auto it = used_positions.find(p.first);
			if (it == used_positions.end())
			{
				used_positions.insert(p.first);
				best_step = p.first;
				break;
			}
		}

		//������������
		if (best_step == -1)
			throw exception("No variants for doing step; curr_pos = " + curr_pos);

		
		//�������� ������ (������� ���)
		checkers * new_player_step = curr_player->step(curr_pos, best_step);
		curr_player = new_player_step;
		//�������� ������� �������
		curr_pos = best_step;
		//��������� �������
		++cnt_steps;
	}
	return cnt_steps;
}


int heuristic1(vector<bool> curr_board, checkers * curr_player)
{
	//����������� ���������� board � player
	vector<bool> old_board = board;
	board = curr_board;
	checkers * old_player = new checkers(curr_player->position, curr_player->num_player, curr_player->parent);

	//��������� - ����� ����� ����� ��� ������ �����, ������� ����� ����� ����� ������ � ������� �������������
	int sum_cost = 0;
	for (int i = 0; i < 12; ++i)
	{
		sum_cost += cnt_steps_to_best_free_pos(board, curr_player, curr_player->position[i]);
	}

	//�������������� ���������� board � player
	board = old_board;
	curr_player = old_player;

	return sum_cost;
}

void step(vector<bool> & cur_board, checkers* cur, int num_check, int new_positions);

class board_node {
public:
	board_node* parent;
	vector<bool> position;
	int ind, pos;
	int score;
	board_node() :parent(nullptr), ind(0), pos(0) { position.assign(board.begin(), board.end()); }

	board_node(checkers * curr, int i, int ps, board_node* p) : parent(p), ind(i), pos(ps) {
		position = p->position;
		step(position, curr, ind, pos);
	}
};


/*struct bd_comp{
bool operator() (board_node* s1, board_node* s2) const{
return (s1->score < s2->score); //??
}
};*/

//pair<int, int> start(checkers* m, checkers* r);


const int ddepth = 3;

//priority_queue<board_node*,bd_comp> q; 

int minimax(int depth, bool comp, board_node* bd, int a, int b, checkers* me_c, checkers* rival_c);

pair<int, int> start(checkers* m, checkers* r) {
	//��������, ��� ����� �������� ��� �������
	board_node* s = new board_node();
	checkers* me_c = new checkers(*m);
	checkers* rival_c = new checkers(*r);
	int score_gen = minimax(ddepth, true, s, INT_MIN, INT_MAX, me_c, rival_c);
	//board_node* temp = q.top();

	//pair<int,int> pr(temp->ind, temp->pos);
	pair<int, int> pr(1, 1);
	return pr;
}

int minimax(int depth, bool comp, board_node* bd, int a, int b, checkers* me_c, checkers* rival_c) {
	if (comp) {
		if (!depth || me_c->isEnd()) {
			int h = heuristic1(bd->position, me_c);
			bd->score = h;
			return h;
		}
		// ���� ���������
		int score = INT_MIN;
		for (int x = 0; x < me_c->position.size(); ++x) {
			list<int> variants = me_c->variants_of_steps(x);
			for (int y : variants) {
				board_node* next = new board_node(me_c, x, y, bd);
				//if(depth == ddepth) q.push(next);
				score = minimax(depth - 1, false, next, a, b, me_c, rival_c);
				if (next->parent != nullptr) next->parent->score = score;
				a = max(a, score);
				if (a >= b) return score;
			}
		}
	}
	//���� ���������
	else {
		if (!depth || rival_c->isEnd()) {
			int h = heuristic1(bd->position, rival_c);
			bd->score = h;
			return h;
		}
		int score = INT_MAX;
		for (int x = 0; x < rival_c->position.size(); ++x) {
			list<int> variants = rival_c->variants_of_steps(x);
			for (int y : variants) {
				board_node* next = new board_node(rival_c, x, y, bd);
				//if(depth == ddepth) q.push(next);
				score = minimax(depth - 1, true, next, a, b, me_c, rival_c);
				b = min(b, score);
				if (a >= b) return score;
			}
		}
	}
}

void step(vector<bool> & cur_board, checkers* cur, int num_check, int new_positions) {
	cur_board[cur->position[num_check]] = true;
	cur_board[new_positions] = false;
	cur->position[num_check] = new_positions;
}