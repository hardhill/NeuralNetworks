using System;
using System.Collections.Generic;

namespace NeuralNetworks
{
    public class Neuron
    {
        public List<double> Weights { get; }
        public NeuronType NeuronType { get; }
        public double Output { get; private set; }
        public List<double> Inputs { get; }
        public double Delta { get; private set; }
        // конструктор нейрона  с количеством входных сигналов и типом нейрона
        public Neuron(int inputCount,NeuronType type = NeuronType.Normal)
        {
            NeuronType = type;
            Weights = new List<double>();
            Inputs = new List<double>();
            SetWeightsRandomize(inputCount);
        }

        private void SetWeightsRandomize(int inputCount)
        {
            var rnd = new Random();
            for (int i = 0; i < inputCount; i++)
            {
                // количество "весов" соответствует количеству входных сигналов
                Weights.Add(rnd.NextDouble());
                Inputs.Add(0);
            }
        }

        // список входных сигналов преобразуется и выводится на выход
        public double FeedForward(List<double> inputs)
        {
            for (int i = 0; i < inputs.Count; i++)
            {
                Inputs[i] = inputs[i];
            }
            var sum = 0.0;
            for (int i = 0; i < inputs.Count; i++)
            {
                sum += inputs[i] * Weights[i];
            }
            if(NeuronType != NeuronType.Input)
            {
                Output = Sigmoid(sum);
            }
            else
            {
                Output = sum;
            }
            
            return Output;
        }

        private double Sigmoid(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }
        private double SigmoidDx(double x)
        {
            var sigmoid = Sigmoid(x);
            return sigmoid / (1 - sigmoid);
        }
        // TODO: этот метод надо удалить
        public void SetWeights(params double[] weights)
        {
            for (int i = 0; i < weights.Length; i++)
            {
                Weights[i] = weights[i];
            }
        }

        public void Learn(double error, double learningRate)
        {
            if(NeuronType == NeuronType.Input)
            {
                return;
            }
            Delta = SigmoidDx(Output);
            for(int i = 0; i < Weights.Count; i++)
            {
                var weight = Weights[i];
                var input = Inputs[i];
                var newWeight = weight - input * Delta * learningRate;
                Weights[i] = newWeight;
            }
        }
        public override string ToString()
        {
            return Output.ToString();
        }
    }
}