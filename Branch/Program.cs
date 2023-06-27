class Branch {

    private List<Branch> Branches;
    public Branch()
    {
        Branches = new List<Branch>();
    }
    public void addBranch(Branch branch)
    {
        Branches.Add(branch);
    }
    public void removeBranch(Branch branch)
    {
        Branches.Remove(branch);
    }
    public List<Branch> getBranches() {
        return Branches;
    }
    public void removeindex(int index)
    {
        Branches.RemoveAt(index);
    }
    public Branch getindex(int index)
    {
        return Branches[index];
    }
    public int getdepth()
    {
        if (this == null || getBranches().Count == 0)
        {
            return 0;
        }
        return 1 + helper(0,0, this);
    }
    public int helper(int index, int depth, Branch branch)
    {
        if(index < branch.getBranches().Count)
        {
            depth = Math.Max(depth, branch.getBranches()[index].getdepth());
            return helper(++index, depth, branch);
        }
        return depth;
    }
    public static void Main(String[] args)
    {
        Branch branch = new Branch();

        Branch branch1 = new Branch();
        Branch branch2 = new Branch();
        branch2.addBranch(new Branch());
        branch1.addBranch(branch2 );

        Branch branch3 = new Branch();
        branch3.addBranch(branch1);
        branch3.addBranch(branch2);

        Branch branch4 = new Branch();
        branch4.addBranch(branch1);
        branch4.addBranch(branch2);

        branch3.addBranch(branch4);

        branch.addBranch(branch1);
        branch.addBranch(branch3);

        Console.WriteLine(branch.getdepth());
        Console.ReadKey();
    }
}
