﻿using System.Collections.Generic;

namespace NeuralNetworks
{
    public class Layer
    {
        public List<Neuron> Neurons { get; }
        public int NeuronCount => Neurons?.Count ?? 0;
        public NeuronType NeuronType { get; }

        public Layer(List<Neuron> neurons, NeuronType neuronType = NeuronType.Normal)
        {
            //TODO: проверить все входные нейроны соответствие типу
            Neurons = neurons;
            NeuronType = neuronType;
        }

        public List<double> GetSignals()
        {
            var result = new List<double>();
            foreach (var neuron in Neurons)
            {
                result.Add(neuron.Output);
            }
            return result;
        }

        public override string ToString()
        {
            return NeuronType.ToString();
        }
    }
}