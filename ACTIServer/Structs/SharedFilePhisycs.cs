using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ACTIServer.Structs
{
    public class SharedFilePhisycs
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SPageFilePhysics
        {
            [MarshalAs(UnmanagedType.U4)]
           
            public int packetId;

            [MarshalAs(UnmanagedType.R4)]
            public float gas;

            [MarshalAs(UnmanagedType.R4)]
            public float brake;

            [MarshalAs(UnmanagedType.R4)]
            public float fuel;

            [MarshalAs(UnmanagedType.R4)]
            public float gear;

            [MarshalAs(UnmanagedType.R4)]
            public float rpms;

            [MarshalAs(UnmanagedType.R4)]
            public float steerAngle;

            [MarshalAs(UnmanagedType.R4)]
            public float speedKmh;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public float[] velocity;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public float[] accg;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public float[] wheelSlip;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public float[] wheelLoad;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public float[] wheelPressure;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public float[] wheelAngularSpeed;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public float[] tyreWear;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public float[] tyreDirtyLevel;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public float[] tyreCoreTemp;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public float[] camberRadian;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public float[] suspesionTravel;

            [MarshalAs(UnmanagedType.R4)]
            public float drs;

            [MarshalAs(UnmanagedType.R4)]
            public float tractionControlLevel;

            [MarshalAs(UnmanagedType.R4)]
            public float heading;

            [MarshalAs(UnmanagedType.R4)]
            public float pitch;

            [MarshalAs(UnmanagedType.R4)]
            public float roll;

            [MarshalAs(UnmanagedType.R4)]
            public float cgHeight;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public float[] carDamaged;

            [MarshalAs(UnmanagedType.U4)]
            public int numberOfTyresOutFromTrack;

            [MarshalAs(UnmanagedType.U4)]
            public int pitlimiter;

            [MarshalAs(UnmanagedType.R4)]
            public float abs;

            [MarshalAs(UnmanagedType.R4)]
            public float kersCharge;

            [MarshalAs(UnmanagedType.R4)]
            public float kersInToEngine;

            [MarshalAs(UnmanagedType.U4)]
            public int autoShifterOn;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public float[] rideHeight;

            [MarshalAs(UnmanagedType.R4)]
            public float turboBoost;

            [MarshalAs(UnmanagedType.R4)]
            public float ballast;

            [MarshalAs(UnmanagedType.R4)]
            public float airDensity;

            [MarshalAs(UnmanagedType.R4)]
            public float airTemp;

            [MarshalAs(UnmanagedType.R4)]
            public float roadTemp;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public float[] localAngularVec;

            [MarshalAs(UnmanagedType.R4)]
            public float finalFF;

            [MarshalAs(UnmanagedType.R4)]
            public float performanceMeter;

            [MarshalAs(UnmanagedType.U4)]
            public int engineBrake;

            [MarshalAs(UnmanagedType.U4)]
            public int ersRecoveryLevel;

            [MarshalAs(UnmanagedType.U4)]
            public int ersPowerLevel;

            [MarshalAs(UnmanagedType.U4)]
            public int ersHeatCahrging;

            [MarshalAs(UnmanagedType.U4)]
            public int erslsCharging;

            [MarshalAs(UnmanagedType.R4)]
            public float kersCurrentKJ;

            [MarshalAs(UnmanagedType.U4)]
            public int drsAvailable;

            [MarshalAs(UnmanagedType.U4)]
            public int drsEnabled;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public float[] brakeTemp;

            [MarshalAs(UnmanagedType.R4)]
            public float clutch;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public float[] tyreTempInner;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public float[] tyreTempCenter;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public float[] tyreTempOuter;

            [MarshalAs(UnmanagedType.U4)]
            public int isAiControlled;

            [MarshalAs(UnmanagedType.R4)]
            public float braikeBais;

        }

        public SPageFilePhysics ByteArrayToNewStuff(byte[] bytes)
        {
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            SPageFilePhysics stuff = (SPageFilePhysics)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(SPageFilePhysics));
            handle.Free();
            return stuff;
        }
    }
}
