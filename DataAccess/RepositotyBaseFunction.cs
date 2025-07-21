namespace back_end.DataAccess
{
    public class RepositotyBaseFunction
    {
        public int funcGetLastIndex(List<string> list, int vt)
        {
            if(list.Count == 0)
            {
                return 1;
            }
            List<int> STT = list.Select(ma => 
            int.TryParse(ma.Substring(vt), out int number) ? number : -1)
                .Where(number => number != -1).ToList();
            STT.Sort();
            return STT[STT.Count - 1] + 1;
        }
    }
}
