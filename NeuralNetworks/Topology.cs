using System.Collections.Generic;

namespace NeuralNetworks
{
    public class Topology
    {
        public int InputCount { get; }
        public int OutputCount { get; }
        public List<int> HiddenLayers { get; }
        public double LearningRate { get; }

        public Topology(int inputCount,int outputCount, double learningRate, params int[] layers)
        {
            InputCount = inputCount;
            OutputCount = outputCount;
            HiddenLayers = new List<int>();
            HiddenLayers.AddRange(layers);
            LearningRate = learningRate;
        }
    }
}