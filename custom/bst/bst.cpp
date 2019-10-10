// bst.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>

using namespace std;

template <class T>
struct Node {
	Node* left;
	Node* right;
	T value;
public:
	Node() {
		this->value;
		this->left = NULL;
		this->right = NULL;
	}
	Node(T value) {
		this->value = value;
		this->left = NULL;
		this->right = NULL;
	}
};

/*

*/
template <class T>
class Bst {

public:
	Node<T> root;
	/* Create a Binary search tree */
	Bst(vector<T> toSort) {
		Node<T>* rootPointer = &this->root;
		rootPointer = NULL;
		for (T item : toSort) {
			this->insert(rootPointer, item);
		}
		if (rootPointer != NULL) {
			this->root = *rootPointer;
		}
	}
	/*
	Insert into the tree

	*/
	void insert(Node<T>*& root, T item) {
		if (!root)
			root = new Node<T>(item);
		else if (item < root->value)
			insert(root->left, item);
		else if (item > root->value)
			insert(root->right, item);
	};
	Node<T>* deleteNode(T value) {
		Node<T>* rootPointer = &this->root;
		return deleteNode(rootPointer, value);
	}
	/*
	Assumption, anythig in the current BST is unique
	*/
	Node<T>* deleteNode(Node<T>*& root, T value) {
		// first find the node
		if (root == NULL) return root;
		else if (value < root->value)	return deleteNode(root->left, value);
		else if (value > root->value) return deleteNode(root->right, value);
		else {
			// Case 1
			if (root->left == NULL && root->right == NULL) {
				delete root;
				root = NULL;
			}
			else if (root->left == NULL && root->right != NULL) {
				Node<T>* temp = root;
				root = root->right;
				delete temp;
				temp = NULL;
			}
			else if (root->left != NULL && root->right == NULL) {
				Node<T>* temp = root;
				root = root->left;
				delete temp;
				temp = NULL;
			}
			else {
				// Case 3
				Node<T>* temp= findMinimum(root->right);
				root->value = temp->value;
				root->right = deleteNode(root->right, temp->value);
			}
		}
	}

	Node<T>* findMinimum() {
		return findMinimum(&this->root);
	}
	Node<T>* findMinimum(Node<T>* root) {
		if (!root->left) {
			return root;
		}
		else {
			return findMinimum(root->left);
		}
	}
};

void tests() {
	Bst<int> bst = Bst<int>({ -5, -10, -60, -50 });
	if (bst.findMinimum()->value != -60) {
		throw runtime_error(string("Find mimum is incorrect"));
	}
	bst = Bst<int>({ -5, 1 });
	bst.deleteNode(1);

	if (bst.root.right) {
		throw runtime_error(string("Delete node has a memory leak."));
	}

}
int main()
{
	tests();
	vector<int> toSort = { -5, 3, 65, 2, 76, -50 };

	Bst<int> bst = Bst<int>(toSort);
	cout << "Hello World!\n";
}
