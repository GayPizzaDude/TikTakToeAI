using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;


namespace ttt_ai.Classes
{
    class Transformer
    {
        // --- PROPERTIES ---

        private List<int> sequence;

        private List<float> encodingWeights;

        private float[,] positionEmbedingVector;



        // --- CONSTRUCTOR ---

        public Transformer(List<int> inputSequence)
        {
            sequence = inputSequence;
        }



        // --- PUBLIC METHODS ---

        public void Encoding()
        {
            int [] input_vecotr = sequence.ToArray();
            encodingWeights = InitiateEncodingWeights(input_vecotr.GetLength(1));
        }


        // --- PRIVATE METHODS ---

        private void InitiatePositionEmbedingVector(int size)
        {
            for (int i = 0;i < size;i++)
            {
                if (i % 2 == 0)
                {
                    SineEmbeding(i, size, )
                }
            }
        }

        private float SineEmbeding(int position, int size, int i)
        {
            double denominator = (2 * i) / size;
            double result = Math.Sin((double)position / denominator);

            return (float)result;
        }

        private float CosineEmbeding(int position, int size, int i)
        {

        }

        private float[,] HadMul(int[,] inputMatrixA, float[,] inputMatrixB)
        {
            int n = inputMatrixA.GetLength(0);
            int m = inputMatrixA.GetLength(1);

            float[,] outputMatrix = new float[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    outputMatrix[i, j] = (float)inputMatrixA[i, j] * inputMatrixB[i, j];
                }
            }

            return outputMatrix;
        }

        private int[,] MatMul(int[,] matrixA, int[,] matrixB)
        {
            int n = matrixA.GetLength(0);
            int m = matrixB.GetLength(1);

            int[,] outputMatrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    outputMatrix[i, j] = CountMatrixElement(i, j, matrixA, matrixB);
                }
            }

            return outputMatrix;
        }

        private int CountMatrixElement(int i_id, int j_id, int[,] matrixA, int[,] matrixB)
        {
            int innerSize = matrixA.GetLength(1);

            int result = 0;

            for (int i = 0;i < innerSize; i++)
            {
                result += matrixA[i_id, i] * matrixB[i, j_id];
            }

            return result;
        }

        private List<float> InitiateEncodingWeights(int size) 
        {
            List<float> outputList = new List<float>();
            Random rng = new Random();

            for (int i = 0; i < size; i++)
            {
                outputList.Add((float)rng.NextDouble());
            }

            return outputList;
        }
    }
}
