using Application.Repositories;
using Application.Response;
using Domain.Entities;
using FluentValidation;
using Mapster;
using MediatR;

namespace Application.Commands
{
    public class RegisterTrain
    {
        public record RegisterTrainCommand(string TrainNo, string EngineNo) : IRequest<BaseResponse<RegisterTrainResponse>>;
        
        public class RegisterTrainHandler(ITrainRepository trainRepository, IUnitOfWork unitOfWork) : IRequestHandler<RegisterTrainCommand, BaseResponse<RegisterTrainResponse>>
        {
            public async Task<BaseResponse<RegisterTrainResponse>> Handle(RegisterTrainCommand request, CancellationToken cancellationToken)
            {
                var trainExist = await trainRepository.IsExist(request.TrainNo);
                if (trainExist) throw new Exception($"{request.TrainNo} already exist");
                var train = new Train
                {
                    EngineNo = request.EngineNo,
                    TrainNo = request.TrainNo
                };
                await trainRepository.AddAsync(train);
                await unitOfWork.SaveAsync();
                return BaseResponse<RegisterTrainResponse>.Success(train.Adapt<RegisterTrainResponse>(), "created");
            }
        }

        public record RegisterTrainResponse(Guid Id);
        public class RegisterTrainValidator : AbstractValidator<RegisterTrainCommand>
        {
            public RegisterTrainValidator()
            {
                RuleFor(x => x.EngineNo)
                    .NotEmpty()
                    .WithMessage("Engine number required");

                RuleFor(x => x.TrainNo)
                    .NotEmpty()
                    .WithMessage("Train number required");
            }
        }
    }
}
