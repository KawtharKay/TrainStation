using Application.Repositories;
using Application.Response;
using Domain.Entities;
using Domain.Enums;
using FluentValidation;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public class CreateCoach
    {
        public record CreateCoachCommand(Guid TrainId, string CoachNo, int Capacity, BookingClass BookingClass) : IRequest<BaseResponse<CreateCoachResponse>>;
        
        public class CreateCoachHandler(ICoachRepository coachRepository, IUnitOfWork unitOfWork, ICurrentUser currentUser, ISeatRepository seatRepository) : IRequestHandler<CreateCoachCommand, BaseResponse<CreateCoachResponse>>
        {
            public async Task<BaseResponse<CreateCoachResponse>> Handle(CreateCoachCommand request, CancellationToken cancellationToken)
            {
                var coachExist = await coachRepository.IsExist(request.TrainId, request.CoachNo);
                if (coachExist) throw new Exception($"{request.CoachNo} already exist");
                var no = await coachRepository.GetTrainCoachCount(request.TrainId);
                var coach = new Coach
                {
                    TrainId = request.TrainId,
                    CoachNo = request.CoachNo,
                    Capacity = request.Capacity,
                    CoachOrder = no + 1,
                    BookingClass = request.BookingClass,
                    CreatedBy = currentUser.GetCurrentUser().ToString()
                };
                await coachRepository.AddAsync(coach);

                for(int i = 1; i<=coach.Capacity;i++)
                {
                    var seat = new Seat
                    {
                        CoachId = coach.Id,
                        SeatNo = i
                    };
                    await seatRepository.AddAsync(seat);
                }
                await unitOfWork.SaveAsync();
                return BaseResponse<CreateCoachResponse>.Success(coach.Adapt<CreateCoachResponse>(), "Coach created successfully");
            }
        }

        public record CreateCoachResponse(Guid Id);
        public class CreateCoachCommandValidator : AbstractValidator<CreateCoachCommand>
        {
            public CreateCoachCommandValidator()
            {
                RuleFor(x => x.TrainId)
                    .NotEmpty()
                    .WithMessage("Train ID is required");

                RuleFor(x => x.CoachNo)
                    .NotEmpty()
                    .WithMessage("Coach number is required");

                RuleFor(x => x.Capacity)
                    .GreaterThan(0)
                    .WithMessage("Capacity must be greater than 0");

                RuleFor(x => x.BookingClass)
                    .IsInEnum()
                    .WithMessage("Invalid booking class");
            }
        }
    }
}
