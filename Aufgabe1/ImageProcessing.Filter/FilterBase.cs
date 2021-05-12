namespace ImageProcessing
{
    public class FilterBase
    {
        protected readonly IPadding myPadder;

        public FilterBase(IPadding _Padder)
        {
            myPadder = _Padder;
        }
    }
}