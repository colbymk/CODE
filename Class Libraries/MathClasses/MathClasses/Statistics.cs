using System;
using System.Collections.Generic;
using System.Linq;

namespace MathClasses
{
    public class Statistics
    {
        // method to find the mean value of a vector (array)
        public double Mean(double[] vec)
        {
            // find length of vector and convert to double
            int dim = vec.GetLength(0);
            double dimD = Convert.ToDouble(dim);

            // find mean value
            double output = 0.0;
            for (int i = 0; i < dim; i++)
            {
                output += vec[i];
            }
            output /= dimD;
            return output;
        }

        // method to find standard deviation of a vector (array)
        public double StandardDeviation(double[] vector)
        {
            // find mean
            double mean = Mean(vector);

            // define output
            double output = 0.0;

            // find sum of square error
            for (int i = 0; i < vector.GetLength(0); i++)
            {
                output += (vector[i] - mean) * (vector[i] - mean);
            }

            // mean mean squared error
            output /= Convert.ToDouble(vector.GetLength(0));

            // find standard deviation
            output = Math.Sqrt(output);

            // return output
            return output;
        }

        // method to find statistical data from many runs
        public double[,] RunStats(List<double[]> statsData)
        {
            // find number of timesteps and statruns
            int timeSteps = statsData[0].GetLength(0);
            int statRuns = statsData.Count();

            // create temporary vector and output vector
            double[,] output = new double[timeSteps, 3];
            double[] tempVec;

            // for each timestep, find data from each stat run and find mean and error in the mean
            for (int ts = 0; ts < timeSteps; ts++)
            {
                tempVec = new double[statRuns];
                for (int sr = 0; sr < statRuns; sr++)
                {
                    tempVec[sr] = statsData[sr][ts];
                }
                output[ts, 0] = Convert.ToDouble(ts);
                output[ts, 1] = Mean(tempVec);
                output[ts, 2] = StandardDeviation(tempVec) / Math.Sqrt(Convert.ToDouble(statRuns));
            }

            return output;
        }
    }
}



