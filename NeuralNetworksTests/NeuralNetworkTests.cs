﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuralNetworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.Tests
{
    [TestClass()]
    public class NeuralNetworkTests
    {
        [TestMethod()]
        public void FeedForwardTest()
        {
            var dataset = new List<Tuple<double, double[]>>
            {
                // Результат = 1 - пациент болен
                //              0 - пациент здоров
                // неправильная температура = T
                // Хороший возраст = A
                // Курит S
                // Правильно питается F
                //                                           T  A  S  F   
                new Tuple<double, double[]>(0, new double[] {0, 0, 0, 0}),
                new Tuple<double, double[]>(0, new double[] {0, 0, 0, 1}),
                new Tuple<double, double[]>(1, new double[] {0, 0, 1, 0}),
                new Tuple<double, double[]>(0, new double[] {0, 0, 1, 1}),
                new Tuple<double, double[]>(0, new double[] {0, 1, 0, 0}),
                new Tuple<double, double[]>(0, new double[] {0, 1, 0, 1}),
                new Tuple<double, double[]>(1, new double[] {0, 1, 1, 0}),
                new Tuple<double, double[]>(0, new double[] {0, 1, 1, 1}),
                new Tuple<double, double[]>(1, new double[] {1, 0, 0, 0}),
                new Tuple<double, double[]>(1, new double[] {1, 0, 0, 1}),
                new Tuple<double, double[]>(1, new double[] {1, 0, 1, 0}),
                new Tuple<double, double[]>(1, new double[] {1, 0, 1, 1}),
                new Tuple<double, double[]>(1, new double[] {1, 1, 0, 0}),
                new Tuple<double, double[]>(0, new double[] {1, 1, 0, 1}),
                new Tuple<double, double[]>(1, new double[] {1, 1, 1, 0}),
                new Tuple<double, double[]>(1, new double[] {1, 1, 1, 1}),
            };
            var topology = new Topology(4, 1, 2);
            var neuralNetwork = new NeuralNetwork(topology);
            var difference = neuralNetwork.Learn(dataset, 1000);
            var results = new List<double>();
            foreach (var data in dataset)
            {
                results.Add(neuralNetwork.FeedForward(data.Item2).Output);
            }

            for (int i = 0; i < results.Count; i++)
            {
                var expected = Math.Round(dataset[i].Item1, 4);
                var actual = Math.Round(results[i], 4);
                Assert.AreEqual(expected,actual);
            }
            
        }
    }
}