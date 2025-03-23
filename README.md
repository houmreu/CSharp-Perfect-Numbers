# Mersenne Prime & Perfect Number Finder

This program searches for [Mersenne primes](https://en.wikipedia.org/wiki/Mersenne_prime) and their corresponding [Perfect numbers](https://en.wikipedia.org/wiki/Perfect_number) using the **Lucas-Lehmer test**. The program first verifies if a given exponent is prime and if it is, it applies the Lucas-Lehmer test to determine whether the Mersenne number of the form **2^p - 1** is prime.

While C# provides an easy and readable implementation, it is not the most efficient for larger numbers, as low-level languages like C can perform these calculations significantly faster.

To analyze its performance, the program includes a **timer** (class Stopwatch) that measures the computation time for each tested exponent.

---

### Prime Number Check
Before testing for Mersenne primes, the program verifies whether the exponent **p** is a prime number

1. If **p** is less than 2 or an even number greater than 2, it is not prime.
2. The method checks divisibility for all odd numbers up to **√p**.
3. If no divisors are found, **p** is prime.

### Lucas-Lehmer Test
The **Lucas-Lehmer test** is a specialized test for Mersenne numbers

1. Compute the Mersenne number:

   $$M_p = 2^p - 1$$

2. Initialize:

   $$s_0 = 4$$

3. Perform $p - 2$ iterations using this formula:

   $$s_{n+1} = (s_n^2 - 2) \mod M_p$$

4. If the final value of $s$ is 0, then $M_p$ is prime

If a Mersenne prime is found, the program calculates the corresponding **perfect number** using the formula:

$$P = 2^{p-1} \times (2^p - 1)$$
