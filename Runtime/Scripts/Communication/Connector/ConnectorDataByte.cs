namespace OC.Communication
{
    [System.Serializable]
    public class ConnectorDataByte : Connector
    {
        public byte ControlData;
        public byte StatusData;

        public ConnectorDataByte(Link link) : base(link)
        {

        }

        protected override void CreateVariableDescription()
        {
            base.CreateVariableDescription();
            _variablesDescription.Add(new ClientVariableDescription { Name = _link.Path + ".ControlData", Direction = ClientVariableDirection.Input });
            _variablesDescription.Add(new ClientVariableDescription { Name = _link.Path + ".StatusData", Direction = ClientVariableDirection.Output });
        }

        public override void Read()
        {
            base.Read();
            _variables[2].Read(ref ControlData);
        }

        public override void Write()
        {
            base.Write();
            _variables[3].Write(StatusData);
        }
    }
}
