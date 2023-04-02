using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace sfml_list_example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press ESC key to close window");
            MyWindow window = new MyWindow();
            window.Run();
            Console.WriteLine("All done");
        }
    }

    class MyWindow
    {
        RenderWindow window;
        Clock clock;

        Time delta;

        LinkedList<Ball> balls;
        float circleSize;

        Random random;
        float speed;

        Font font;
        Text text;

        public MyWindow()
        {
            VideoMode mode = new VideoMode(1280, 720);
            window = new RenderWindow(mode, "SFML.NET Data Structure Example", Styles.Titlebar);

            window.Closed += this.Window_close;
            window.KeyPressed += this.Key_press;
            window.MouseButtonPressed += this.Mouse_press;

            clock = new Clock();
            delta = Time.Zero;

            balls = new LinkedList<Ball>();
            circleSize = 20f;

            random = new Random();
            speed = 200f;

            font = new Font(@"C:\\Windows\Fonts\Arial.ttf");
            text = new Text("Left-click to add a node. Right-click to remove a node. Escape to quit.", font, 25);
        }

        ////////////// Game Window Critical Methods ///////////////
        public void Run()
        {
            while (window.IsOpen)
            {
                this.Update();
                this.Display();
            }
        }

        public void Update()
        {
            window.DispatchEvents();

            delta = clock.Restart();

            this.UpdateCircles();
        }

        public void Display()
        {
            /// clear the window
            window.Clear();

            /// draw shapes to the window
            this.DrawCircles();

            /// draw the help text
            window.Draw(text);

            /// display the window to the screen
            window.Display();
        }


        ////////////// Game Window Event Methods ///////////////
        public void Key_press(object sender, KeyEventArgs e)
        {
            Window window = (Window)sender;
            
            switch(e.Code)
            {
                case Keyboard.Key.Escape:
                    window.Close();
                    break;
                default:
                    break;
            }
        }

        public void Mouse_press(object sender, MouseButtonEventArgs e)
        {
            switch(e.Button)
            {
                case Mouse.Button.Left:
                    this.AddBall(e.X, e.Y);
                    break;
                case Mouse.Button.Right:
                    this.balls.Dequeue();
                    break;
                default:
                    break;
            }
        }

        public void Window_close(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Close();
        }

        public void AddBall(float x, float y)
        {
            for(int i = 0; i < 1; i++)
            {
                float velocityX = (float)(random.NextDouble() - 0.5) * speed;
                float velocityY = (float)(random.NextDouble() - 0.5) * speed;
                
                Ball ball = new Ball(Color.Red, Color.White, circleSize);
                ball.setPosition(x, y);
                ball.setVelocity(velocityX, velocityY);
                
                balls.Enqueue(ball);
            }
        }

        public void DrawCircles()
        {
            if (this.balls.count == 0) return;

            // draw all the ball links first so they don't draw over the balls
            for (Node<Ball> trav = this.balls.head; trav != null; trav = trav.next)
            {
                trav.data.DrawLink(window, RenderStates.Default);
            }

            for (Node<Ball> trav = this.balls.head; trav != null; trav = trav.next)
            {
                trav.data.Draw(window, RenderStates.Default);
            }
        }

        public void UpdateCircles()
        {
            if (this.balls.count == 0) return;

            for (Node<Ball> trav = this.balls.head; trav != null; trav = trav.next)
            {
                Vector2f linktarget = trav.next != null ? trav.next.data.Position : trav.data.Position;
                // line above is the same as:
                // if (trav.next != null)
                //     linktarget = trav.next.data.Position;
                // else
                //     linktarget = trav.data.Position;

                trav.data.Update(this.delta.AsSeconds(), linktarget, 0, 0, window.Size.X, window.Size.Y);
            }
        }

    }
}
