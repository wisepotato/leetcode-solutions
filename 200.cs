

public class Solution {
    private char[][] _grid;
    private int _xlength;
    private int _ylength;
    private int[][] _cases = new int[][]{
      new int[]{ -1, 0 },
      new int[]{ 1, 0 },
      new int[]{ 0, -1 },
      new int[]{ 0, 1},  
    };
    public int NumIslands(char[][] grid) {
        _grid = grid;
        int islands = 0;
        if(grid.Length == 0){
            return 0;
        }
        _xlength = grid[0].Length;
        _ylength = grid.Length;
        for(int x = 0; x< _xlength; x++){
            for(int y =0; y < _ylength; y++){
                if(grid[y][x] == '1'){
                        islands++;
                      SearchIsland(x,y);
                }
            }
        }
        
        return islands;
    }
    void SearchIsland(int x, int y){
        if((x< 0 || x >= _xlength) || (y < 0 || y>= _ylength) ){
            return;
        }
        if(_grid[y][x] == '0' || _grid[y][x] == '2'){
            return;
        }
        _grid[y][x] = '2';
   
        foreach(var specificCase in _cases){
            SearchIsland(x + specificCase[0], y+ specificCase[1]);
        }
    }
}
