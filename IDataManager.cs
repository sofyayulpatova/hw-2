namespace homework2;

public interface IDataManager
    {
        public string Print();

        public bool Save(string path);

        public bool Load(string path);

        public String CreateTestData();

        public bool Reset();

    }