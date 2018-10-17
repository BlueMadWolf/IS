#pragma once
#include <iostream>
#include <vector>
#include <string>
#include <list>
#include <set>
#include <queue>
#include <algorithm>
#include <fstream>


using namespace std;

vector<bool> board(64, false); //��� �������� ������ �� ���������� �������

pair<int, int> answer;

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
			if (right_free(new_pos) && steps.find(new_pos + 1) == steps.end() && find(new_steps.begin(), new_steps.end(), new_pos + 1) == new_steps.end())
			{
				new_steps.push_back(new_pos + 1);
				new_pos += 1;
				new_variants_of_steps(new_pos, steps, new_steps);
			}
		}

		if (our_pos % 8 != 0 && !left_free(our_pos)) //��������� ������ �����
		{
			int new_pos = our_pos -  1;
			if (left_free(new_pos) && steps.find(new_pos - 1) == steps.end() && find(new_steps.begin(), new_steps.end(), new_pos - 1) == new_steps.end())
			{
				new_steps.push_back(new_pos - 1);
				new_pos -= 1;
				new_variants_of_steps(new_pos, steps, new_steps);
			}
		}

		if (our_pos / 8 != 7 && !up_free(our_pos)) //��������� ������ �����
		{
			int new_pos = our_pos + 8;
			if (up_free(new_pos) && steps.find(new_pos + 8) == steps.end() && find(new_steps.begin(), new_steps.end(), new_pos + 8) == new_steps.end())
			{
				new_steps.push_back(new_pos + 8);
				new_pos += 8;
				new_variants_of_steps(new_pos, steps, new_steps);
			}
		}

		if (our_pos / 8 != 0 && !down_free(our_pos)) //��������� ������ ����
		{
			int new_pos = our_pos - 8;
			if (down_free(new_pos) && steps.find(new_pos - 8) == steps.end() && find(new_steps.begin(), new_steps.end(), new_pos - 8) == new_steps.end())
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
	vector<int> variants_of_best_position(30);
	if (num_player == 1)
	{
		//������ �������� ��������������
		//variants_of_best_position = {63, 62, 55, 61, 54, 47, 60, 53, 46, 52, 45, 44,
			//��������� � �������� ��������������
			//39, 59, 38, 51, 37, 43, 36, 35, 31, 58, 30, 50, 29, 42, 28, 34, 27, 26};
		variants_of_best_position[0] = 63;
		variants_of_best_position[1] = 62;
		variants_of_best_position[2] = 55;
		variants_of_best_position[3] = 61;
		variants_of_best_position[4] = 54;
		variants_of_best_position[5] = 47;
		variants_of_best_position[6] = 60;
		variants_of_best_position[7] = 53;
		variants_of_best_position[8] = 46;
		variants_of_best_position[9] = 52;
		variants_of_best_position[10] = 45;
		variants_of_best_position[11] = 44;
		variants_of_best_position[12] = 39;
		variants_of_best_position[13] = 59;
		variants_of_best_position[14] = 38;
		variants_of_best_position[15] = 51;
		variants_of_best_position[16] = 37;
		variants_of_best_position[17] = 43;
		variants_of_best_position[18] = 36;
		variants_of_best_position[19] = 35;
		variants_of_best_position[20] = 31;
		variants_of_best_position[21] = 58;
		variants_of_best_position[22] = 30;
		variants_of_best_position[23] = 50;
		variants_of_best_position[24] = 29;
		variants_of_best_position[25] = 42;
		variants_of_best_position[26] = 28;
		variants_of_best_position[27] = 34;
		variants_of_best_position[28] = 27;
		variants_of_best_position[29] = 26;
	}
	else
	{
		//������ �������� ��������������
		//variants_of_best_position = { 0, 1, 8, 2, 9, 16, 3, 10, 17, 11, 18, 19,
			//��������� � �������� ��������������
		//	24, 4, 25, 12, 26, 20, 27, 28, 32, 5, 33, 13, 34, 21, 35, 29, 36, 37};

		variants_of_best_position[0] = 0;
		variants_of_best_position[1] = 1;
		variants_of_best_position[2] = 8;
		variants_of_best_position[3] = 2;
		variants_of_best_position[4] = 9;
		variants_of_best_position[5] = 16;
		variants_of_best_position[6] = 3;
		variants_of_best_position[7] = 10;
		variants_of_best_position[8] = 17;
		variants_of_best_position[9] = 11;
		variants_of_best_position[10] = 18;
		variants_of_best_position[11] = 19;
		variants_of_best_position[12] = 24;
		variants_of_best_position[13] = 4;
		variants_of_best_position[14] = 25;
		variants_of_best_position[15] = 12;
		variants_of_best_position[16] = 26;
		variants_of_best_position[17] = 20;
		variants_of_best_position[18] = 27;
		variants_of_best_position[19] = 28;
		variants_of_best_position[20] = 32;
		variants_of_best_position[21] = 5;
		variants_of_best_position[22] = 33;
		variants_of_best_position[23] = 13;
		variants_of_best_position[24] = 34;
		variants_of_best_position[25] = 21;
		variants_of_best_position[26] = 35;
		variants_of_best_position[27] = 29;
		variants_of_best_position[28] = 36;
		variants_of_best_position[29] = 37;
	}

	for (int i = 0; i < variants_of_best_position.size(); ++i)
	{
		if (!curr_board[variants_of_best_position[i]])
			return variants_of_best_position[i];
	}
	return 0;
}

//���������� ����� �� ������� ������� �� ���������, ��������� � �������������� 
int cnt_steps_to_best_free_pos(vector<bool>& curr_board, checkers * curr_player, int curr_num)
{
	int best_pos = closest_to_goal_free_position(curr_board, curr_player->num_player);
	
	int curr_pos = curr_player->position[curr_num];
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
			return 16;//throw exception("No variants for doing step; curr_pos = " + curr_pos);

		
		//�������� ������ (������� ���)
		checkers * new_player_step = curr_player->step(curr_num, best_step);
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
		sum_cost += cnt_steps_to_best_free_pos(board, curr_player, i);
	}

	//�������������� ���������� board � player
	board = old_board;
	curr_player = old_player;

	return sum_cost;
}

int cntInHouse(checkers* curr_player)
{
	int cnt = 0;
	if (curr_player->num_player == 1)
	{
		for (auto pos : curr_player->position)
		{
			if ((pos % 8 < 4) && (pos / 8 < 3))
				++cnt;
		}
	}
	if (curr_player->num_player == 2)
	{
		for (auto pos : curr_player->position)
		{
			if ((pos % 8 > 3) && (pos / 8 > 4))
				++cnt;
		}
	}

	return cnt;
}

int heuristic2(vector<bool> curr_board, checkers * curr_player)
{
	int sum_cost = cntInHouse(curr_player);

	for (int i = 0; i < 12; ++i)
	{
		manhattan_dist(curr_player->position[i], 63);
	}

	return 100 - sum_cost;
}



const int ddepth = 3;
auto heuristic = heuristic2;
checkers* m1;
checkers* r1;

void step(vector<bool> & cur_board, checkers* cur, int num_check, int new_positions) {
	cur_board[cur->position[num_check]] = false;
	cur_board[new_positions] = true;
	cur->position[num_check] = new_positions;
}

void additionalAB(vector<bool> cboard, checkers * player1, checkers * player2, int depth, bool comp, int & a, int & b)
{
	if (depth == 0)
	{
		if (comp)
			a = heuristic(cboard, new checkers(player1->position, player1->num_player));
		else
			a = heuristic(cboard, new checkers(player2->position, player2->num_player));
		return;
	}

	if (comp)
	{
		for (int x = 0; x < 12; ++x)
		{
			checkers * c = new checkers(player1->position, player1->num_player);
			checkers * c1 = new checkers(player2->position, player2->num_player);

			auto v = c->variants_of_steps(c->position[x]);
			for (auto y : v)
			{
				step(cboard, c, x, y);
				int a1 = a;
				int b1 = b;
				additionalAB(cboard, c, c1, depth - 1, false, a1, b1);

				if (a1 > a)
				{
					a = a1;
				}
			}

			delete c;
			delete c1;
		}
	}
	else
	{
		for (int x = 0; x < 12; ++x)
		{
			checkers * c1 = new checkers(player1->position, player1->num_player);
			checkers * c = new checkers(player2->position, player2->num_player);

			auto v = c->variants_of_steps(c->position[x]);
			for (auto y : v)
			{
				step(cboard, c, x, y);
				int a1 = a;
				int b1 = b;
				additionalAB(cboard, c1, c, depth - 1, false, a1, b1);

				if (a1 > a)
				{
					a = a1;
				}
			}

			delete c;
			delete c1;
		}
		

	}
}

pair<int, int> abAlgorithm(checkers * player, vector<bool> curboard,  int a, int b)
{
	pair<int, int> nanswer(-1, -1);
	
	for (int x = 0; x < 12; ++x)
	{
		checkers * c = new checkers(player->position, player->num_player);
		auto v = player->variants_of_steps(player->position[x]);
		for (auto y : v)
		{
			step(curboard, c, x, y);
			int a1 = a;
			int b1 = b;

			checkers * newrival = new checkers(r1->position, r1->num_player);
			additionalAB(curboard, player, newrival, ddepth - 1, false, a1, b1);

			if (a1 > a)
			{
				a = a1;
				nanswer.first = x;
				nanswer.second = y;
			}

			delete newrival;
		}

		delete c;
	}

	return nanswer;
}



class node{
public:
	//checkers* me_c;
	//checkers* rival_c;
	vector<bool> curr_board;

	node(vector<bool> bd): curr_board(bd){
	}
};

node* next_move;

int newminimax(node* cur, checkers* curr_p, vector<bool> cur_board, bool comp, int depth, int a, int b){
	int test = -1;
	node* best_move = nullptr;
	int score = 0;
	vector<bool> oldb = cur_board;
	if(comp){ //TRUE - ���������
		if(depth == 0 || curr_p->isEnd())
			return heuristic2(cur->curr_board, curr_p);
		score = INT_MIN;
		for (int x = 0; x < curr_p->position.size(); ++x){
			list<int> v = curr_p->variants_of_steps(curr_p->position[x]);
			for (int y : v) {
				step(cur_board,curr_p, x, y);
				/*cout << endl <<"step, player = me, depth = " << depth << endl;
						for(int i = 0; i < cur_board.size(); ++ i)
							cout << cur_board[i] << " ";
						cout << endl;*/
				node* next = new node(cur_board);			
				test = newminimax(next,r1,cur_board,0,depth-1,a,b); //����� ���� ����� ����������
				if(test > score){
					score = test;
					best_move = next;
				}
				//cur_board = oldb;
				a = max(a, test);
				if (a >= b) goto br;
			}
		}
	}
	else{
		if(depth == 0 || curr_p->isEnd())
			return heuristic2(cur->curr_board, curr_p);
		score = INT_MAX;
		for (int x = 0; x < curr_p->position.size(); ++x){
			list<int> v = curr_p->variants_of_steps(curr_p->position[x]);
			for (int y : v) {
				step(cur_board,curr_p, x, y);
				/*cout << endl <<"step, player = rival, depth = " << depth << endl;
						for(int i = 0; i < cur_board.size(); ++ i)
							cout << cur_board[i] << " ";
						cout << endl;*/
				node* next = new node(cur_board);			
				test = newminimax(next,m1,cur_board,1,depth-1,a,b); //����� ���� ����� ���
				if(test <= score){
					score = test;
					best_move = next;
				}
				//cur_board = oldb;
				b = min(b, test);
				if (a >= b) goto br;
			}
		}
	}

	br:
	if (depth == ddepth && best_move != nullptr){
		next_move = best_move;
		cout << endl <<"best_move" << endl;
		for(int i = 0; i < best_move->curr_board.size(); ++ i)
			cout << best_move->curr_board[i] << " ";
		cout << endl;
	}
	return score;
}

void newstart(){
	node* st = new node(board);
	m1 = new checkers(*me);
	r1 = new checkers(*rival);
	//next_move = new node(board);
	//newminimax(st,m1,board,1,ddepth,INT_MIN,INT_MAX);
	answer = abAlgorithm(m1, board, INT_MIN, INT_MIN);
}

pair<int, int> find_step(vector<bool> oldboard, vector<bool> newboard) { 
	int old_pos, new_pos; 

	for (int i = 0; i < 64; ++i){
		if (oldboard[i] != newboard[i]) 
		if (oldboard[i]) 
			old_pos = i; 
		else 
			new_pos = i; 
	}
	return pair<int, int>(old_pos, new_pos); 
}

int find_index(vector<int> vpos, int pos) { 
	int indx = -1;

	for (int i = 0; i < 12; ++i) 
		if (vpos[i] == pos) 
		indx = i; 
	return indx; 
}