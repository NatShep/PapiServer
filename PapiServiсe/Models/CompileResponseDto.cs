using System.Collections.Generic;

namespace PapiServiсe.Models
{
    public class CompileResponseDto
    {
        public IEnumerable<FaceDto> Faces { get; set; }
    }
}