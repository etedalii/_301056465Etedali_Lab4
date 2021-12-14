using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.S3;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Etedali_StepFunction
{
    public class StepFunctionTasks
    {
        IAmazonS3 S3Client { get; set; }

        /// <summary>
        /// Default constructor that Lambda will invoke.
        /// </summary>
        public StepFunctionTasks()
        {
            S3Client = new AmazonS3Client();
        }


        public async Task<State> IsUploadedImage(State state, ILambdaContext context)
        {
            try
            {
                var response = await this.S3Client.GetObjectMetadataAsync(state.BucketName, state.Key);
                if (response.Headers.ContentType.StartsWith("image"))
                {
                    DecisionFunction(state, context, true);
                    return state;
                }
                else
                {
                    DecisionFunction(state, context, false);
                    return state;
                }
            }
            catch (Exception e)
            {
                context.Logger.LogLine($"Error getting object {state.BucketName} from bucket {state.Key}. Make sure they exist and your bucket is in the same region as this function.");
                context.Logger.LogLine(e.Message);
                context.Logger.LogLine(e.StackTrace);
                throw;
            }
        }

        public State DecisionFunction(State state, ILambdaContext context, bool status)
        {
            if (!status)
                return End(state, context);

            return state;
        }

        public State DetectLabelSaveDynamoDb(State state, ILambdaContext context)
        {
            return state;
        }

        public State GenerateThumbnailImage(State state, ILambdaContext context)
        {
            return state;
        }

        public State End(State state, ILambdaContext context)
        {
            return state;
        }
    }
}
