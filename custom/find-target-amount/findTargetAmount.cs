using System;
using System.Collections.Generic;
public class Program
{
	public int Target = -1;
	public int Found  = 0;
	public static void Main()
	{
		var program = new Program();
		program.Target =7 ;
		var toCheck = new int[] { 1,2,3,4,4,5,6,7,7,7,7,7,7,8};
		program.DivideAndCheck(toCheck);
		
		Console.Out.WriteLine(program.Found == 6);
		toCheck = new int[] {};
		program.Reset();
		program.Target = 4;
		program.DivideAndCheck(toCheck);
		Console.Out.WriteLine(program.Found == 0);

		
	}
	public void Reset(){
		Found = 0;
		Target = -1;
	}
	public void DivideAndCheck(int[] arr){
		int n = arr.Length;
		if(n== 0){
		return;
		}
		if(n == 1 && arr[0] == Target){
			Found++;
			return;
		}
		int amountLeft = Convert.ToInt32(n % 2 == 0 ? n/2 : (n+1)/2);
		int amountRight = n - amountLeft;

		if(arr[0] <= Target && arr[amountLeft-1] >= Target ){
			int[] left = new int[amountLeft];
			Array.Copy(arr, 0, left, 0, amountLeft);
			DivideAndCheck(left);
		}
		if(arr[amountLeft] <= Target && arr[n-1] >=  Target){
			int[] right =  new int[amountRight];
			Array.Copy(arr, amountLeft, right, 0, amountRight);
			DivideAndCheck(right);
		}
	}
}