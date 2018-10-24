#include<iostream>
#include<fstream>
#include<string>
#include<ctime>
#include<map>
#include<set>
#include<vector>
#include<list>
#include<algorithm>
#include<functional>
#include<queue>
#include<stack>
#include<iomanip>


using namespace std;

class State
{
public:
	State * pred;
	int num_step;

	vector<int> board;
	int heuristic = 0;
	map<int, int> incorrect_queens;
	multimap<int, int, greater<int>> iq_vice_versa;


	State(vector<int> board, int num_step, State* pred = nullptr)
	{
		this->board = board;
		calc_heuristic();
		this->pred = pred;
		this->num_step = num_step;
	}

	void calc_heuristic()
	{
		heuristic = 0;
		incorrect_queens.clear();
		iq_vice_versa.clear();
		for (int i = 0; i < board.size(); ++i)
		{
			for (int j = i + 1; j < board.size(); ++j)
			{
				if ((board[i] == board[j]) || (board[i] == (board[j] - (j - i))) || (board[i] == (board[j] + (j - i))))
				{
					heuristic += 2;
					++incorrect_queens[i];
					++incorrect_queens[j];
				}
			}
		}
		for (int i = 0; i < board.size(); ++i)
			iq_vice_versa.insert(make_pair(incorrect_queens[i], i));
	}

	bool move_ith_down(int i)
	{
		if (board[i] > 0)
		{
			--board[i];
			calc_heuristic();
			return true;
		}
		return false;
	}

	bool move_ith_up(int i)
	{
		if (board[i] < 7)
		{
			++board[i];
			calc_heuristic();
			return true;
		}
		return false;
	}

	void print_incorrect_queens()
	{
		for (int i = 0; i < incorrect_queens.size(); ++i)
			cout << i << ": " << incorrect_queens[i] << endl;
		cout << endl;
	}
	void print_iq_vice_versa()
	{
		int i = 0;
		for (auto x: iq_vice_versa)
			cout << x.first << ": " << x.second << endl;
		cout << endl;
	}

	void print_board()
	{
		for (int i = 0; i < board.size(); ++i)
		{
			int j = 0;
			for (; j < board[i]; ++j)
			{
				cout << "- ";
			}
			cout << "* ";
			++j;
			for (; j < board.size(); ++j)
			{
				cout << "- ";
			}
			cout << endl;
		}
		cout << endl;
	}
};

State* bfs(State* init_state)
{
	set<vector<int>> used;
	used.insert(init_state->board);
	queue<State*> q;
	q.push(init_state);

	while (true)
	{
		State* curr = q.front();
		q.pop();

		if (curr->heuristic == 0)
		{
			return curr;
		}

		if (used.size() % 2000 == 0)
			cout << used.size() << endl;

		for (auto& p : curr->iq_vice_versa)
		{

			State* next1 = new State(curr->board, curr->num_step + 1, curr);
			State* next2 = new State(curr->board, curr->num_step + 1, curr);
			next1->move_ith_down(p.second);
			next2->move_ith_up(p.second);

			auto it1 = used.find(next1->board);
			auto it2 = used.find(next2->board);

			if (it1 == used.end())
			{
				q.push(next1);
				used.insert(next1->board);
			}
			if (it2 == used.end())
			{
				q.push(next2);
				used.insert(next2->board);
			}
		}
	}
}

State* dfs(State* init_state)
{
	set<vector<int>> used;
	used.insert(init_state->board);
	stack<State*> s;
	s.push(init_state);

	while (true)
	{
		State* curr = s.top();
		s.pop();

		if (curr->heuristic == 0)
		{
			return curr;
		}

		for (auto it = curr->iq_vice_versa.rbegin(); it != curr->iq_vice_versa.rend(); ++it)
		{
			pair<int, int> p = *it;
			State* next1 = new State(curr->board, curr->num_step + 1, curr);
			State* next2 = new State(curr->board, curr->num_step + 1, curr);
			next1->move_ith_down(p.second);
			next2->move_ith_up(p.second);

			auto it1 = used.find(next1->board);
			auto it2 = used.find(next2->board);

			if (used.size() % 2000 == 0)
				cout << used.size() << endl;

			if (it1 == used.end())
			{
				s.push(next1);
				used.insert(next1->board);
			}
			if (it2 == used.end())
			{
				s.push(next2);
				used.insert(next2->board);
			}
		}
	}
}


class State2
{
public:
	State2 * pred;

	vector<int> board;
	int heuristic;

	State2(vector<int> board) { this->board = board; calc_heuristic(); }
	State2()
	{
		board.resize(8);
		fill(board.begin(), board.end(), -1);
	}

	void set_ith_to_h(int i, int h)
	{
		board[i] = h;
		calc_heuristic();
	}

	int first_free_index()
	{
		int ind = 0;
		for (ind = 0; ind < board.size(); ++ind)
		{
			if (board[ind] == -1)
				break;
		}
		return ind;
	}

	void set_first_free_to_h(int h)
	{
		int ind = first_free_index();
		if (ind < 8)
			board[ind] = h;
		calc_heuristic();
	}

	void calc_heuristic()
	{
		heuristic = 0;
		int free = first_free_index();
		for (int i = 0; i < free; ++i)
		{
			for (int j = i + 1; j < free; ++j)
			{
				if ((board[i] == board[j]) || (board[i] == (board[j] - (j - i))) || (board[i] == (board[j] + (j - i))))
				{
					heuristic += 2;
				}
			}
		}
	}

	void print_board()
	{
		int w = 5;
		cout << setw(w);
		for (int i = 0; i < board.size(); ++i)
		{
			int j = 0;
			for (; j < board[i]; ++j)
			{
				cout << setw(w) << "[]";
			}
			cout << setw(w) << "MM";
			++j;
			for (; j < board.size(); ++j)
			{
				cout << setw(w) << "[]";
			}
			cout << endl;
			cout << endl;
		}
		cout << endl;
	}
};


State2 * last_state2 = nullptr;

bool try_set(State2* s)
{
	bool res = false;
	int free = s->first_free_index();
	if (free == 8)
	{
		if (s->heuristic == 0)
		{
			last_state2 = s;
			return true;
		}
		else
			return false;
	}
	
	for (int i = 0; i < 8; ++i)
	{
		State2* news = new State2(s->board);
		news->set_ith_to_h(free, i);
		int h = news->heuristic;
		if (h == 0)
		{
			if (try_set(news))
				return true;
			else
				delete news;
		}
		else
		{
			delete news;
		}
	}
	return false;
}


int main()
{
	/*
	State * s1 = new State({ 0, 0, 0, 0, 0, 0, 0, 0 }, 0);
	
	time_t st, en;


	s1->print_board();
	s1->print_iq_vice_versa();

	st = clock();
	State* last = bfs(s1);
	en = clock();
	cout << "time = " << double(st - en) / CLOCKS_PER_SEC;

	last->print_board();
	*/

	//last = dfs(s1);
	//last->print_board();

	/*cout << s.heuristic << endl;
	s.print_incorrect_queens();
	s.print_iq_vice_versa();*/

	vector<int> v = { 6, -1, -1, -1,
					-1, -1, -1, -1 };

	State2 * s2 = new State2(v);

	time_t st, en;

	st = clock();
	bool is_set = try_set(s2);
	en = clock();
	cout << "time = " << double(en-st) / CLOCKS_PER_SEC << endl << endl;

	if (is_set)
		last_state2->print_board();
	else
		cout << "No solution" << endl;

	system("pause");
}