using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightingAndCamerasExample
{
    public interface ICamera
    {
        Matrix View { get; }

        Matrix Projection { get; }
    }
}
