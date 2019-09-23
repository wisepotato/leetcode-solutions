/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode MergeKLists(ListNode[] lists) {
        int length = lists.Length;
        if(lists.Length == 0){
            return null;
        } else if (lists.Length ==1){
            return lists[0];
        }
        return Divider(lists);
    }
    public ListNode Divider(ListNode[] lists){
        int length = lists.Length;
        if(length == 2){
            
             var startNode = new ListNode(-1);
            Comparer(lists[0], lists[1], startNode);
            return startNode.next;
        }
        if(length % 2 ==0){
            // we are even so go forth!
            ListNode[] resultset = new ListNode[Convert.ToInt32(length/2)];
            for(int i =0; i< length;i= i+2){
                var startNode = new ListNode(-1);
                Comparer(lists[i], lists[i+1], startNode);
                resultset[Convert.ToInt32(i/2)]  = startNode.next;
            }
            return Divider(resultset);
        } else {
            ListNode[] resultset = new ListNode[Convert.ToInt32((length-1)/2) +1];
            for(int i = 0; i< Convert.ToInt32((length-1)/2); i++){
                 var startNode = new ListNode(-1);
                Comparer(lists[2*i], lists[2*i+1], startNode);
                resultset[i]  = startNode.next;
                
            }
            resultset[resultset.Length -1] = lists[lists.Length -1];
            return Divider(resultset);
        }

    }
    public void Comparer(ListNode listOne, ListNode listTwo, ListNode resultNode){
        if(listOne == null && listTwo == null){
            return;
        }
        if(listOne == null){
            resultNode.next =  new ListNode(listTwo.val);
              Comparer(null, listTwo.next, resultNode.next);
            return;
        } 
        if(listTwo == null){
            resultNode.next = new ListNode(listOne.val);
            Comparer(listOne.next, null, resultNode.next);
            
        } else if(listTwo.val <= listOne.val){
            resultNode.next = new ListNode(listTwo.val);
            Comparer(listOne, listTwo.next, resultNode.next);
        } else if(listOne.val < listTwo.val){
            resultNode.next = new ListNode(listOne.val);
            Comparer(listOne.next, listTwo, resultNode.next);
        } 
    }
}

