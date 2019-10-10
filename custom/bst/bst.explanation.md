# Custom BST

In C++ make a binary ttree and make an example  + explain how to:

* Create
* Insert
* Delete 
* Search

## Create

For every item in the list of ints provided

1. If no root exists, create it with the value provided
2. A root exists, so:
   * if the value provided is less the node examining, take the left child and act as if the left child is the root
   * If value > root val, take the right child and act is if it is the root

Return a reference to the root

# Delete

* Locate the node to be deleted (by checking on value /item), 

then three cases:

1. Leaf node
   * If the node is a leaf node, set the pointer for the parent to null on left
   * if the node is a right leaf node set the poitner for the parent to null on righ
2. Has one child (left/right)
   1. Take out this node
3. if the node has two kids:
   * Get the minimum of the right subtree, and replace its value with the current node, 