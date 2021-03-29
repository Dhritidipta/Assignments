namespace Program3
{
    class JumpCount
    {
        private int count = 0;
        public byte[] TestArray { get; private set; }

        public JumpCount(byte[] arr)
        {
            TestArray = arr;//{0, 0, 1, 0, 0}
        }

        public int MinJump()
        {
            if (TestArray.Length == 0)
                return 0;
            else
            {
                for (int i = 0; i < TestArray.Length-1; i++)
                {
                    if (i == TestArray.Length - 2)//i.e. 2nd last bit
                    {
                        if (TestArray[i + 1] == 0)
                            count++;
                        break;
                    }
                    else
                    {
                        if (TestArray[i + 2] == 0)
                        {
                            ++i;
                            count++;
                        }

                        else if (TestArray[i + 1] == 0)
                            count++;

                        else
                        {
                            for (i += 1; i < TestArray.Length; i++)
                            {
                                if (TestArray[i] == 0)
                                {
                                    count = -1;
                                    return count;
                                }
                            }
                        }
                    }
                }
            }
            return count;
        }

    }

}

